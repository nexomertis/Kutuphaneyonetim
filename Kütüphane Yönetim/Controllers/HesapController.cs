using Microsoft.AspNetCore.Mvc;
using KutuphaneyYonetim.Data;
using KutuphaneyYonetim.Models;

namespace KutuphaneyYonetim.Controllers
{
    public class HesapController : Controller
    {
        private readonly KütüphaneDbContext _context;

        public HesapController(KütüphaneDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult KayitOl()
        {
            return View();
        }
        [HttpPost]
        public IActionResult KayitOl(string Ad, string Soyad, string TelefonNumarası, string Email, string Şifre)
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Şifre) || string.IsNullOrEmpty(TelefonNumarası))
            {
                ViewBag.Hata = "Email, telefon ve şifre zorunludur!";
                return View();
            }

            if (!Email.Contains("@") || !Email.Contains("."))
            {
                ViewBag.Hata = "Geçerli bir email adresi girin!";
                return View();
            }

            if (Şifre.Length < 6)
            {
                ViewBag.Hata = "Şifre en az 6 karakter olmalı!";
                return View();
            }

            if (_context.Kullanıcılar.Any(k => k.Email == Email))
            {
                ViewBag.Hata = "Bu email adresi zaten kayıtlı!";
                return View();
            }

            var kullanıcı = new Kullanıcı
            {
                Ad = Ad ?? "",
                Email = Email,
                Şifre = Şifre
            };
            _context.Kullanıcılar.Add(kullanıcı);

            var üye = new Üye
            {
                Ad = Ad ?? "",
                Soyad = Soyad ?? "",
                TelefonNumarası = TelefonNumarası,
                Email = Email,
                OluşturulmaTarihi = DateTime.Now
            };
            _context.Üyeler.Add(üye);

            _context.SaveChanges();
            return RedirectToAction("GirisYap");
        }
        [HttpGet]
        public IActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GirisYap(string email, string sifre)
        {
            if (email == "admin@admin.com" && sifre == "admin123")
            {
                HttpContext.Session.SetString("KullaniciAd", "Admin");
                HttpContext.Session.SetString("AdminMi", "True");
                return RedirectToAction("Index", "Home");
            }
            var kullannici  = _context.Kullanıcılar
                .FirstOrDefault(k => k.Email == email && k.Şifre == sifre);
            if (kullannici == null)
            {
                ViewBag.Hata = "Email veya şifre hatalı!";
                return View();
                 
            }
            HttpContext.Session.SetString("KullaniciAd", kullannici.Ad);
            HttpContext.Session.SetString("KullaniciEmail", kullannici.Email);
            HttpContext.Session.SetString("AdminMi", kullannici.AdminMi.ToString());
            return RedirectToAction("Index", "Home");
        }
        public IActionResult CikisYap()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        
        public IActionResult Profilim()
        {
            var email = HttpContext.Session.GetString("KullaniciEmail");
            if (email == null)
            {
                return RedirectToAction("GirisYap");
            }

            var üye = _context.Üyeler.FirstOrDefault(u => u.Email == email);
            if (üye == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(üye);
        }

        [HttpGet]
        public IActionResult AdminGiris()
        {
            return View();
        }

       
    }
    
    
}
