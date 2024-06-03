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
    public class LabAdresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LabAdresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LabAdres
        public async Task<IActionResult> Index()
        {
            return View(await _context.LabAdresler.ToListAsync());
        }

        // GET: LabAdres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labAdres = await _context.LabAdresler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (labAdres == null)
            {
                return NotFound();
            }

            return View(labAdres);
        }

        // GET: LabAdres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LabAdres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ad,KoridorNo,KatNo,TelefonNo")] LabAdres labAdres)
        {
            if (ModelState.IsValid)
            {
                _context.Add(labAdres);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(labAdres);
        }

        // GET: LabAdres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labAdres = await _context.LabAdresler.FindAsync(id);
            if (labAdres == null)
            {
                return NotFound();
            }
            return View(labAdres);
        }

        // POST: LabAdres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,KoridorNo,KatNo,TelefonNo")] LabAdres labAdres)
        {
            if (id != labAdres.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(labAdres);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LabAdresExists(labAdres.Id))
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
            return View(labAdres);
        }

        // GET: LabAdres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var labAdres = await _context.LabAdresler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (labAdres == null)
            {
                return NotFound();
            }

            return View(labAdres);
        }

        // POST: LabAdres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var labAdres = await _context.LabAdresler.FindAsync(id);
            if (labAdres != null)
            {
                _context.LabAdresler.Remove(labAdres);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LabAdresExists(int id)
        {
            return _context.LabAdresler.Any(e => e.Id == id);
        }
    }
}
