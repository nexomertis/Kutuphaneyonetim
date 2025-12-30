using Microsoft.AspNetCore.Mvc;
using KutuphaneyYonetim.Models;
using KutuphaneyYonetim.Data;
using Microsoft.EntityFrameworkCore;

namespace KutuphaneyYonetim.Controllers
{
    public class KitaplarController : Controller
    {
        private readonly KütüphaneDbContext _context;

        public KitaplarController(KütüphaneDbContext context)
        {
            _context = context;
        }

        [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
        public IActionResult Index(string kategori)
        {
            var kitaplar = _context.Kitaplar.AsQueryable();

            if (!string.IsNullOrEmpty(kategori))
            {
                kitaplar = kitaplar.Where(k => k.Kategori == kategori);
            }

            var kullaniciEmail = HttpContext.Session.GetString("KullaniciEmail");
            if (!string.IsNullOrEmpty(kullaniciEmail))
            {
                var üye = _context.Üyeler.FirstOrDefault(u => u.Email == kullaniciEmail);
                if (üye != null)
                {
                    var bugün = DateTime.Today;
                    var bugünÖdünçAlinanKitaplar = _context.ÖdünçKayıtları
                        .Where(k => k.ÜyeId == üye.Id && k.ÖdünçTarihi.Date == bugün)
                        .Select(k => k.KitapId)
                        .ToList();

                    ViewBag.BugünÖdünçAlinanKitaplar = bugünÖdünçAlinanKitaplar;
                }
            }

            ViewBag.SecilenKategori = kategori;
            ViewBag.Kategoriler = GetKategoriler();

            return View(kitaplar.ToList());
        }

        private List<string> GetKategoriler()
        {
            return new List<string>
            {
                "Roman", "Biyografi", "Bilim Kurgu", "Fantastik",
                "Tarih", "Spor", "Klasik", "Macera"
            };
        }

        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("AdminMi") != "True")
            {
                return RedirectToAction("Index");
            }
            ViewBag.Kategoriler = GetKategoriler();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Kitap kitap)
        {
            if (HttpContext.Session.GetString("AdminMi") != "True")
            {
                return RedirectToAction("Index");
            }
            kitap.OluşturulmaTarihi = DateTime.Now;
            kitap.MevcutKopya = kitap.ToplamKopya;
            kitap.Kategori = kitap.Kategori ?? "Genel";
            kitap.Ozet = kitap.Ozet ?? "";
            _context.Kitaplar.Add(kitap);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("AdminMi") != "True")
            {
                return RedirectToAction("Index");
            }
            var kitap = _context.Kitaplar.Find(id);
            if (kitap == null)
            {
                return NotFound();
            }
            ViewBag.Kategoriler = GetKategoriler();
            return View(kitap);
        }

        [HttpPost]
        public IActionResult Edit(int id, Kitap kitap)
        {
            if (HttpContext.Session.GetString("AdminMi") != "True")
            {
                return RedirectToAction("Index");
            }
            if (id != kitap.Id)
            {
                return NotFound();
            }

            var mevcutKitap = _context.Kitaplar.Find(id);
            if (mevcutKitap == null)
            {
                return NotFound();
            }

            mevcutKitap.Baslik = kitap.Baslik;
            mevcutKitap.Yazar = kitap.Yazar;
            mevcutKitap.ISBN = kitap.ISBN;
            mevcutKitap.ResimUrl = kitap.ResimUrl;
            mevcutKitap.ToplamKopya = kitap.ToplamKopya;
            mevcutKitap.MevcutKopya = kitap.MevcutKopya;
            mevcutKitap.Kategori = kitap.Kategori ?? "Genel";
            mevcutKitap.Ozet = kitap.Ozet ?? "";

            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("AdminMi") != "True")
            {
                return RedirectToAction("Index");
            }
            var kitap = _context.Kitaplar.Find(id);
            if (kitap == null)
            {
                return NotFound();
            }
            return View(kitap);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetString("AdminMi") != "True")
            {
                return RedirectToAction("Index");
            }
            var kitap = _context.Kitaplar.Find(id);
            if (kitap != null)
            {
                _context.Kitaplar.Remove(kitap);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult OduncAl(int id)
        {
            var kullaniciAd = HttpContext.Session.GetString("KullaniciAd");
            if (kullaniciAd == null)
            {
                return RedirectToAction("GirisYap", "Hesap");
            }

            var kitap = _context.Kitaplar.Find(id);
            if (kitap == null || kitap.MevcutKopya <= 0)
            {
                return RedirectToAction("Index");
            }

            var kullaniciEmail = HttpContext.Session.GetString("KullaniciEmail");
            var üye = _context.Üyeler.FirstOrDefault(u => u.Email == kullaniciEmail);
            if (üye == null)
            {
                return RedirectToAction("Index");
            }

            var bugün = DateTime.Today;
            var ayniGunOduncVar = _context.ÖdünçKayıtları
                .Any(k => k.ÜyeId == üye.Id &&
                k.KitapId == kitap.Id &&
                k.ÖdünçTarihi.Date == bugün);
            if (ayniGunOduncVar)
            {

                TempData["Hata"] = $"Bugün zaten '{kitap.Baslik}' kitabını ödünç aldınız! Aynı kitabı günde sadece bir kez ödünç alabilirsiniz.";
                return RedirectToAction("Index");
            }
            var kayıt = new ÖdünçKaydı
            {
                ÜyeId = üye.Id,
                KitapId = kitap.Id,
                ÖdünçTarihi = DateTime.Now,
                SonİadeTarihi = DateTime.Now.AddMinutes(2)
            };

            kitap.MevcutKopya = kitap.MevcutKopya - 1;
            _context.ÖdünçKayıtları.Add(kayıt);
            _context.SaveChanges();

            TempData["Mesaj"] = $"{kitap.Baslik} kitabı başarıyla ödünç alındı! Son iade tarihi: {kayıt.SonİadeTarihi:dd.MM.yyyy}";

            return RedirectToAction("Index");
        }

        public IActionResult Kitaplarim()
        {
            var kullaniciEmail = HttpContext.Session.GetString("KullaniciEmail");
            if (kullaniciEmail == null)
            {
                return RedirectToAction("GirisYap", "Hesap");
            }

            var üye = _context.Üyeler.FirstOrDefault(u => u.Email == kullaniciEmail);
            if (üye == null)
            {
                return RedirectToAction("Index");
            }

            var kayıtlar = _context.ÖdünçKayıtları
                .Where(k => k.ÜyeId == üye.Id && k.İadeTarihi == null)
                .Include(k => k.Kitap)
                .ToList();

            return View(kayıtlar);
        }

        public IActionResult IadeEt(int id)
        {
            var kullaniciEmail = HttpContext.Session.GetString("KullaniciEmail");
            if (kullaniciEmail == null)
            {
                return RedirectToAction("GirisYap", "Hesap");
            }

            var üye = _context.Üyeler.FirstOrDefault(u => u.Email == kullaniciEmail);
            if (üye == null)
            {
                return RedirectToAction("Index");
            }

            var kayıt = _context.ÖdünçKayıtları
                .Include(k => k.Kitap)
                .FirstOrDefault(k => k.KitapId == id && k.ÜyeId == üye.Id && k.İadeTarihi == null);

            if (kayıt != null)
            {
                kayıt.İadeTarihi = DateTime.Now;
                var kitap = _context.Kitaplar.Find(id);
                if (kitap != null)
                {
                    kitap.MevcutKopya = kitap.MevcutKopya + 1;
                }
                _context.SaveChanges();
                TempData["Mesaj"] = $"'{kayıt.Kitap.Baslik}' kitabı başarıyla iade edildi!";
            }

            return RedirectToAction("Kitaplarim");
        }

        public IActionResult Gecmisim()
        {
            var kullaniciEmail = HttpContext.Session.GetString("KullaniciEmail");
            if (kullaniciEmail == null)
            {
                return RedirectToAction("GirisYap", "Hesap");
            }

            var üye = _context.Üyeler.FirstOrDefault(u => u.Email == kullaniciEmail);
            if (üye == null)
            {
                return RedirectToAction("Index");
            }

            var kayıtlar = _context.ÖdünçKayıtları
                .Where(k => k.ÜyeId == üye.Id)
                .Include(k => k.Kitap)
                .OrderByDescending(k => k.ÖdünçTarihi)
                .ToList();

            return View(kayıtlar);
        }

        public IActionResult Ara(string q)
        {
            var kitaplar = _context.Kitaplar.AsQueryable();

            if (!string.IsNullOrEmpty(q))
            {
                var aramaTerimi = q.Trim().ToLowerInvariant();
                kitaplar = kitaplar.Where(k =>
                    k.Baslik.ToLower().Contains(aramaTerimi) ||
                    k.Yazar.ToLower().Contains(aramaTerimi));


                var kullaniciEmail = HttpContext.Session.GetString("KullaniciEmail");
                if (!string.IsNullOrEmpty(kullaniciEmail))
                {
                    var üye = _context.Üyeler.FirstOrDefault(u => u.Email == kullaniciEmail);
                    if (üye != null)
                    {
                        var bugün = DateTime.Today;
                        var bugünÖdünçAlinanKitaplar = _context.ÖdünçKayıtları
                            .Where(k => k.ÜyeId == üye.Id && k.ÖdünçTarihi.Date == bugün)
                            .Select(k => k.KitapId)
                            .ToList();

                        ViewBag.BugünÖdünçAlinanKitaplar = bugünÖdünçAlinanKitaplar;
                    }
                }

            }

            ViewBag.Arama = q;
            return View(kitaplar.ToList());
        }
          public IActionResult Detay(int id)
        {
            var kitap = _context.Kitaplar.Find(id);
            
            if (kitap == null) return NotFound();
            return View(kitap);
        }
    }
}
