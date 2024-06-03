using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Internet_Programlama_Final_Work.Data;
using Internet_Programlama_Final_Work.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Internet_Programlama_Final_Work.Controllers
{
    public class DoktorsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public DoktorsController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Doktors
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["SpecialtySortParm"] = sortOrder == "Specialty" ? "specialty_desc" : "Specialty";

            var doktorlar = from s in _context.Doktorlar
                            select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                doktorlar = doktorlar.Where(s => s.AdSoyad.Contains(searchString)
                                               || s.UzmanlikAlani.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    doktorlar = doktorlar.OrderByDescending(s => s.AdSoyad);
                    break;
                case "Specialty":
                    doktorlar = doktorlar.OrderBy(s => s.UzmanlikAlani);
                    break;
                case "specialty_desc":
                    doktorlar = doktorlar.OrderByDescending(s => s.UzmanlikAlani);
                    break;
                default:
                    doktorlar = doktorlar.OrderBy(s => s.AdSoyad);
                    break;
            }

            return View(await doktorlar.ToListAsync());
        }

        // GET: Doktors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doktor = await _context.Doktorlar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doktor == null)
            {
                return NotFound();
            }

            return View(doktor);
        }

        // GET: Doktors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Doktors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AdSoyad,UzmanlikAlani,DoktorPhoto,ImageFile,Numara,Email")] Doktor doktor)
        {
            if (ModelState.IsValid)
            {
                string wwwrootpath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(doktor.ImageFile.FileName);
                string extension = Path.GetExtension(doktor.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                doktor.DoktorPhoto = "~/Contents/" + fileName;
                string path = Path.Combine(wwwrootpath + "/Contents/", fileName);
                using (var filestream = new FileStream(path, FileMode.Create))
                {
                    await doktor.ImageFile.CopyToAsync(filestream);
                }
                _context.Add(doktor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doktor);
        }

        // GET: Doktors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doktor = await _context.Doktorlar.FindAsync(id);
            if (doktor == null)
            {
                return NotFound();
            }
            return View(doktor);
        }

        // POST: Doktors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AdSoyad,UzmanlikAlani,DoktorPhoto,Numara,Email")] Doktor doktor)
        {
            if (id != doktor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doktor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoktorExists(doktor.Id))
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
            return View(doktor);
        }

        // GET: Doktors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doktor = await _context.Doktorlar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doktor == null)
            {
                return NotFound();
            }

            return View(doktor);
        }

        // POST: Doktors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doktor = await _context.Doktorlar.FindAsync(id);
            if (doktor != null)
            {
                _context.Doktorlar.Remove(doktor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoktorExists(int id)
        {
            return _context.Doktorlar.Any(e => e.Id == id);
        }
    }
}
