using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Test2.Data;
using Test2.Models;

namespace Test2.Controllers
{
    public class JanrsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JanrsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Janrs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Janrs.ToListAsync());
        }

        // GET: Janrs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var janr = await _context.Janrs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (janr == null)
            {
                return NotFound();
            }

            return View(janr);
        }

        // GET: Janrs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Janrs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Janr janr)
        {
            if (ModelState.IsValid)
            {
                _context.Add(janr);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(janr);
        }

        // GET: Janrs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var janr = await _context.Janrs.FindAsync(id);
            if (janr == null)
            {
                return NotFound();
            }
            return View(janr);
        }

        // POST: Janrs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Janr janr)
        {
            if (id != janr.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(janr);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JanrExists(janr.Id))
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
            return View(janr);
        }

        // GET: Janrs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var janr = await _context.Janrs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (janr == null)
            {
                return NotFound();
            }

            return View(janr);
        }

        // POST: Janrs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var janr = await _context.Janrs.FindAsync(id);
            _context.Janrs.Remove(janr);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JanrExists(int id)
        {
            return _context.Janrs.Any(e => e.Id == id);
        }
    }
}
