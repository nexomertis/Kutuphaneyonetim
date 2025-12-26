using Microsoft.AspNetCore.Mvc;
using KutuphaneyYonetim.Models;
using KutuphaneyYonetim.Data;
using Microsoft.EntityFrameworkCore;

namespace KutuphaneyYonetim.Controllers
{
    public class ÖdünçKayıtlarıController : Controller
    {
        private readonly KütüphaneDbContext _context;

        public ÖdünçKayıtlarıController(KütüphaneDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("AdminMi") != "True")
            {
                return RedirectToAction("Index", "Home");
            }
            var kayıtlar = _context.ÖdünçKayıtları.Include(o => o.Üye).Include(o => o.Kitap).ToList();
            return View(kayıtlar);
        }

        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("AdminMi") != "True")
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Üyeler = _context.Üyeler.ToList();
            ViewBag.Kitaplar = _context.Kitaplar.Where(k => k.MevcutKopya > 0).ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(ÖdünçKaydı kayıt)
        {
            if (HttpContext.Session.GetString("AdminMi") != "True")
            {
                return RedirectToAction("Index", "Home");
            }
            var kitap = _context.Kitaplar.Find(kayıt.KitapId);
            if (kitap == null || kitap.MevcutKopya <= 0)
            {
                ModelState.AddModelError("", "Kitap mevcut değil");
                ViewBag.Üyeler = _context.Üyeler.ToList();
                ViewBag.Kitaplar = _context.Kitaplar.Where(k => k.MevcutKopya > 0).ToList();
                return View(kayıt);
            }
            kayıt.ÖdünçTarihi = DateTime.Now;
            kitap.MevcutKopya = kitap.MevcutKopya - 1;
            _context.ÖdünçKayıtları.Add(kayıt);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult ÜyeGeçmişi(int id)
        {
            var kayıtlar = _context.ÖdünçKayıtları
                .Where(o => o.ÜyeId == id)
                .Include(o => o.Kitap)
                .ToList();
            ViewBag.ÜyeId = id;
            return View(kayıtlar);
        }

        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("AdminMi") != "True")
            {
                return RedirectToAction("Index", "Home");
            }
            var kayıt = _context.ÖdünçKayıtları.Include(o => o.Üye).Include(o => o.Kitap).FirstOrDefault(o => o.Id == id);
            if (kayıt == null)
            {
                return NotFound();
            }
            return View(kayıt);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetString("AdminMi") != "True")
            {
                return RedirectToAction("Index", "Home");
            }
            var kayıt = _context.ÖdünçKayıtları.Find(id);
            if (kayıt != null)
            {
                var kitap = _context.Kitaplar.Find(kayıt.KitapId);
                if (kitap != null)
                {
                    kitap.MevcutKopya = kitap.MevcutKopya + 1;
                }
                _context.ÖdünçKayıtları.Remove(kayıt);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
