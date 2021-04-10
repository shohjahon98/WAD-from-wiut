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
    public class MyGroupsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MyGroupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MyGroups
        public async Task<IActionResult> Index()
        {
            return View(await _context.MyGroups.ToListAsync());
        }

        // GET: MyGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myGroup = await _context.MyGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myGroup == null)
            {
                return NotFound();
            }

            return View(myGroup);
        }

        // GET: MyGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MyGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GroupName")] MyGroup myGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(myGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(myGroup);
        }

        // GET: MyGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myGroup = await _context.MyGroups.FindAsync(id);
            if (myGroup == null)
            {
                return NotFound();
            }
            return View(myGroup);
        }

        // POST: MyGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GroupName")] MyGroup myGroup)
        {
            if (id != myGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(myGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyGroupExists(myGroup.Id))
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
            return View(myGroup);
        }

        // GET: MyGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var myGroup = await _context.MyGroups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (myGroup == null)
            {
                return NotFound();
            }

            return View(myGroup);
        }

        // POST: MyGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var myGroup = await _context.MyGroups.FindAsync(id);
            _context.MyGroups.Remove(myGroup);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyGroupExists(int id)
        {
            return _context.MyGroups.Any(e => e.Id == id);
        }
    }
}
