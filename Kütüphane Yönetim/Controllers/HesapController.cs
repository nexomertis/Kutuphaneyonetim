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
        public IActionResult KayitOl(Kullanıcı kullanıcı)
        {
            _context.Kullanıcılar.Add(kullanıcı);
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
            var kullannici  = _context.Kullanıcılar
                .FirstOrDefault(k => k.Email == email && k.Şifre == sifre);
            if (kullannici == null)
            {
                ViewBag.Hata = "Email veya şifre hatalı!";
                return View();
                 
            }
            HttpContext.Session.SetString("KullaniciAd", kullannici.Ad);
            HttpContext.Session.SetString("AdminMi", kullannici.AdminMi.ToString());
            return RedirectToAction("Index", "Home");
        }
        public IActionResult CikisYap()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
    
    
}
