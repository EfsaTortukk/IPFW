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
    public class TestTursController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TestTursController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TestTurs
        public async Task<IActionResult> Index()
        {
            return View(await _context.TestTurler.ToListAsync());
        }

        // GET: TestTurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testTur = await _context.TestTurler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testTur == null)
            {
                return NotFound();
            }

            return View(testTur);
        }

        // GET: TestTurs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TestTurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,LabAdi,AcTok,SonucSuresi")] TestTur testTur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testTur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testTur);
        }

        // GET: TestTurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testTur = await _context.TestTurler.FindAsync(id);
            if (testTur == null)
            {
                return NotFound();
            }
            return View(testTur);
        }

        // POST: TestTurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,LabAdi,AcTok,SonucSuresi")] TestTur testTur)
        {
            if (id != testTur.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testTur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestTurExists(testTur.Id))
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
            return View(testTur);
        }

        // GET: TestTurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testTur = await _context.TestTurler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testTur == null)
            {
                return NotFound();
            }

            return View(testTur);
        }

        // POST: TestTurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testTur = await _context.TestTurler.FindAsync(id);
            if (testTur != null)
            {
                _context.TestTurler.Remove(testTur);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestTurExists(int id)
        {
            return _context.TestTurler.Any(e => e.Id == id);
        }
    }
}
