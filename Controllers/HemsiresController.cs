using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Internet_Programlama_Final_Work.Data;
using Internet_Programlama_Final_Work.Models;

namespace Internet_Programlama_Final_Work.Controllers
{
    public class HemsiresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HemsiresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Hemsires
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hemsireler.ToListAsync());
        }

        // GET: Hemsires/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hemsire = await _context.Hemsireler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hemsire == null)
            {
                return NotFound();
            }

            return View(hemsire);
        }

        // GET: Hemsires/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hemsires/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AdSoyad,Bölüm,Telefon,Email,İşeBaşlamaTarihi")] Hemsire hemsire)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hemsire);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hemsire);
        }

        // GET: Hemsires/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hemsire = await _context.Hemsireler.FindAsync(id);
            if (hemsire == null)
            {
                return NotFound();
            }
            return View(hemsire);
        }

        // POST: Hemsires/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AdSoyad,Bölüm,Telefon,Email,İşeBaşlamaTarihi")] Hemsire hemsire)
        {
            if (id != hemsire.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hemsire);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HemsireExists(hemsire.Id))
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
            return View(hemsire);
        }

        // GET: Hemsires/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hemsire = await _context.Hemsireler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hemsire == null)
            {
                return NotFound();
            }

            return View(hemsire);
        }

        // POST: Hemsires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hemsire = await _context.Hemsireler.FindAsync(id);
            if (hemsire != null)
            {
                _context.Hemsireler.Remove(hemsire);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HemsireExists(int id)
        {
            return _context.Hemsireler.Any(e => e.Id == id);
        }
    }
}
