using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Universite_Web.Data;
using Universite_Web.Models;

namespace Universite_Web.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize]

    public class TotalsController : Controller
    {
        private readonly AppDbContext _context;

        public TotalsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: admin/Totals
        public async Task<IActionResult> Index()
        {
            return View(await _context.Totals.ToListAsync());
        }

        // GET: admin/Totals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var total = await _context.Totals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (total == null)
            {
                return NotFound();
            }

            return View(total);
        }

        // GET: admin/Totals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: admin/Totals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Icon,Numeral,Name")] Total total)
        {
            if (ModelState.IsValid)
            {
                _context.Add(total);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(total);
        }

        // GET: admin/Totals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var total = await _context.Totals.FindAsync(id);
            if (total == null)
            {
                return NotFound();
            }
            return View(total);
        }

        // POST: admin/Totals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Icon,Numeral,Name")] Total total)
        {
            if (id != total.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(total);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TotalExists(total.Id))
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
            return View(total);
        }

        // GET: admin/Totals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var total = await _context.Totals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (total == null)
            {
                return NotFound();
            }

            return View(total);
        }

        // POST: admin/Totals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var total = await _context.Totals.FindAsync(id);
            _context.Totals.Remove(total);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TotalExists(int id)
        {
            return _context.Totals.Any(e => e.Id == id);
        }
    }
}
