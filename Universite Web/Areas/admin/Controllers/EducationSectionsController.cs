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

    public class EducationSectionsController : Controller
    {
        private readonly AppDbContext _context;

        public EducationSectionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: admin/EducationSections
        public async Task<IActionResult> Index()
        {
            return View(await _context.EducationSections.ToListAsync());
        }

        // GET: admin/EducationSections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationSection = await _context.EducationSections
                .FirstOrDefaultAsync(m => m.Id == id);
            if (educationSection == null)
            {
                return NotFound();
            }

            return View(educationSection);
        }

        // GET: admin/EducationSections/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: admin/EducationSections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Country")] EducationSection educationSection)
        {
            if (ModelState.IsValid)
            {
                _context.Add(educationSection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(educationSection);
        }

        // GET: admin/EducationSections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationSection = await _context.EducationSections.FindAsync(id);
            if (educationSection == null)
            {
                return NotFound();
            }
            return View(educationSection);
        }

        // POST: admin/EducationSections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Country")] EducationSection educationSection)
        {
            if (id != educationSection.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(educationSection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EducationSectionExists(educationSection.Id))
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
            return View(educationSection);
        }

        // GET: admin/EducationSections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var educationSection = await _context.EducationSections
                .FirstOrDefaultAsync(m => m.Id == id);
            if (educationSection == null)
            {
                return NotFound();
            }

            return View(educationSection);
        }

        // POST: admin/EducationSections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var educationSection = await _context.EducationSections.FindAsync(id);
            _context.EducationSections.Remove(educationSection);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EducationSectionExists(int id)
        {
            return _context.EducationSections.Any(e => e.Id == id);
        }
    }
}
