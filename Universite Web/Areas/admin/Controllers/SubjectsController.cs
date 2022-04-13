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

    public class SubjectsController : Controller
    {
        private readonly AppDbContext _context;

        public SubjectsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: admin/Subjects
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Subject.Include(s => s.Faculty).Include(s => s.Group).Include(s => s.Specialty);
            return View(await appDbContext.ToListAsync());
        }

        // GET: admin/Subjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.Subject
                .Include(s => s.Faculty)
                .Include(s => s.Group)
                .Include(s => s.Specialty)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // GET: admin/Subjects/Create
        public IActionResult Create()
        {
            ViewBag.FacultyList = _context.Faculties.ToList();
            ViewBag.SpecialtyList = _context.Specialty.ToList();
            return View();
        }

        // POST: admin/Subjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Subject subject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FacultyId"] = new SelectList(_context.Faculties, "Id", "Id", subject.FacultyId);
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Id", subject.GroupId);
            ViewData["SpecialtyId"] = new SelectList(_context.Specialty, "Id", "Id", subject.SpecialtyId);
            return View(subject);
        }

        public JsonResult GetSpecialty(int facultyId)
        {
            var data = _context.Specialty.Where(x => x.FacultyId == facultyId).ToList();
            return Json(data);
        }

        public JsonResult GetGroup(int specialtyId)
        {
            var data = _context.Groups.Where(x => x.SpecialtyId == specialtyId).ToList();
            return Json(data);
        }

        // GET: admin/Subjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.Subject.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            ViewBag.FacultyList = _context.Faculties.ToList();
            ViewBag.SpecialtyList = _context.Specialty.ToList();
            ViewData["SpecialtyId"] = new SelectList(_context.Specialty, "Id", "Name", subject.SpecialtyId);
            return View(subject);
        }

        // POST: admin/Subjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  Subject subject)
        {
            if (id != subject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectExists(subject.Id))
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
            ViewData["FacultyId"] = new SelectList(_context.Faculties, "Id", "Name", subject.FacultyId);
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Name", subject.GroupId);
            ViewData["SpecialtyId"] = new SelectList(_context.Specialty, "Id", "Name", subject.SpecialtyId);
            return View(subject);
        }

        // GET: admin/Subjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.Subject
                .Include(s => s.Faculty)
                .Include(s => s.Group)
                .Include(s => s.Specialty)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // POST: admin/Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subject = await _context.Subject.FindAsync(id);
            _context.Subject.Remove(subject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubjectExists(int id)
        {
            return _context.Subject.Any(e => e.Id == id);
        }
    }
}
