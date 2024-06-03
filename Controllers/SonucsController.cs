using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Internet_Programlama_Final_Work.Data;
using Internet_Programlama_Final_Work.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Internet_Programlama_Final_Work.Controllers
{
    public class SonucsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public SonucsController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: Sonucs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Sonuclar.Include(s => s.Doktor).Include(s => s.Hasta).Include(s => s.Hemsire);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Sonucs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sonuc = await _context.Sonuclar
                .Include(s => s.Doktor)
                .Include(s => s.Hasta)
                .Include(s => s.Hemsire)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sonuc == null)
            {
                return NotFound();
            }

            return View(sonuc);
        }

        // GET: Sonucs/Create
        public IActionResult Create()
        {
            ViewBag.DoktorId = new SelectList(_context.Doktorlar, "Id", "AdSoyad");
            ViewBag.HastaId = new SelectList(_context.Hastalar, "Id", "AdSoyad");
            ViewBag.HemsireId = new SelectList(_context.Hemsireler, "Id", "AdSoyad");

            return View();
        }

        // POST: Sonucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tarih,Fotograf,HastaId,DoktorId,HemsireId")] Sonuc sonuc)
        {
            if (ModelState.IsValid)
            {
                if (sonuc.Fotograf != null)
                {
                    string uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "content");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + sonuc.Fotograf.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await sonuc.Fotograf.CopyToAsync(fileStream);
                    }
                    sonuc.FotografDosyasi = "/content/" + uniqueFileName;
                }

                _context.Add(sonuc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.DoktorId = new SelectList(_context.Doktorlar, "Id", "AdSoyad", sonuc.DoktorId);
            ViewBag.HastaId = new SelectList(_context.Hastalar, "Id", "AdSoyad", sonuc.HastaId);
            ViewBag.HemsireId = new SelectList(_context.Hemsireler, "Id", "AdSoyad", sonuc.HemsireId);

            return View(sonuc);
        }


        // GET: Sonucs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sonuc = await _context.Sonuclar.FindAsync(id);
            if (sonuc == null)
            {
                return NotFound();
            }
            ViewData["DoktorId"] = new SelectList(_context.Doktorlar, "Id", "AdSoyad", sonuc.DoktorId);
            ViewData["HastaId"] = new SelectList(_context.Hastalar, "Id", "AdSoyad", sonuc.HastaId);
            ViewData["HemsireId"] = new SelectList(_context.Hemsireler, "Id", "AdSoyad", sonuc.HemsireId);

            return View(sonuc);
        }

        // POST: Sonucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tarih,FotografDosyasi,HastaId,DoktorId,HemsireId")] Sonuc sonuc)
        {
            if (id != sonuc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sonuc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SonucExists(sonuc.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DoktorId"] = new SelectList(_context.Doktorlar, "Id", "AdSoyad", sonuc.DoktorId);
            ViewData["HastaId"] = new SelectList(_context.Hastalar, "Id", "AdSoyad", sonuc.HastaId);
            ViewData["HemsireId"] = new SelectList(_context.Hemsireler, "Id", "AdSoyad", sonuc.HemsireId);

            return View(sonuc);
        }

        // GET: Sonucs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sonuc = await _context.Sonuclar
                .Include(s => s.Doktor)
                .Include(s => s.Hasta)
                .Include(s => s.Hemsire)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sonuc == null)
            {
                return NotFound();
            }

            return View(sonuc);
        }

        // POST: Sonucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sonuc = await _context.Sonuclar.FindAsync(id);
            if (sonuc != null)
            {
                _context.Sonuclar.Remove(sonuc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SonucExists(int id)
        {
            return _context.Sonuclar.Any(e => e.Id == id);
        }
    }
}
