using Microsoft.AspNetCore.Mvc;
using KutuphaneyYonetim.Models;
using KutuphaneyYonetim.Data;

namespace KutuphaneyYonetim.Controllers
{
    public class KitaplarController : Controller
    {
        private readonly KütüphaneDbContext _context;

        public KitaplarController(KütüphaneDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var kitaplar = _context.Kitaplar.ToList();
            return View(kitaplar);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Kitap kitap)
        {
            kitap.OluşturulmaTarihi = DateTime.Now;
            kitap.MevcutKopya = kitap.ToplamKopya;
            _context.Kitaplar.Add(kitap);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var kitap = _context.Kitaplar.Find(id);
            if (kitap == null)
            {
                return NotFound();
            }
            return View(kitap);
        }

        [HttpPost]
        public IActionResult Edit(int id, Kitap kitap)
        {
            if (id != kitap.Id)
            {
                return NotFound();
            }
            _context.Kitaplar.Update(kitap);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
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
            var kitap = _context.Kitaplar.Find(id);
            if (kitap != null)
            {
                _context.Kitaplar.Remove(kitap);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
