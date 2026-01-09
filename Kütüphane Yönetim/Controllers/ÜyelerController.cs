using Microsoft.AspNetCore.Mvc;
using KutuphaneyYonetim.Models;
using KutuphaneyYonetim.Data;

namespace KutuphaneyYonetim.Controllers
{
    public class ÜyelerController : Controller
    {
        private readonly KütüphaneDbContext _context;

        public ÜyelerController(KütüphaneDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var üyeler = _context.Üyeler.ToList();
            return View(üyeler);
        }

        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("AdminMi") != "True")
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Create(Üye üye)
        {
            if (HttpContext.Session.GetString("AdminMi") != "True")
            {
                return RedirectToAction("Index");
            }
            üye.OluşturulmaTarihi = DateTime.Now;
            _context.Üyeler.Add(üye);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("AdminMi") != "True")
            {
                return RedirectToAction("Index");
            }
            var üye = _context.Üyeler.Find(id);
            if (üye == null)
            {
                return NotFound();
            }
            return View(üye);
        }

        [HttpPost]
        public IActionResult Edit(int id, Üye üye)
        {
            if (HttpContext.Session.GetString("AdminMi") != "True")
            {
                return RedirectToAction("Index");
            }
            if (id != üye.Id)
            {
                return NotFound();
            }
            _context.Üyeler.Update(üye);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("AdminMi") != "True")
            {
                return RedirectToAction("Index");
            }
            var üye = _context.Üyeler.Find(id);
            if (üye == null)
            {
                return NotFound();
            }
            return View(üye);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            if (HttpContext.Session.GetString("AdminMi") != "True")
            {
                return RedirectToAction("Index");
            }
            var üye = _context.Üyeler.Find(id);
            if (üye != null)
            {
                _context.Üyeler.Remove(üye);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
