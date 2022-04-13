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

    public class SocialsController : Controller
    {
        private readonly AppDbContext _context;

        public SocialsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: admin/Socials
        public async Task<IActionResult> Index()
        {
            return View(await _context.Socials.ToListAsync());
        }

        // GET: admin/Socials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var social = await _context.Socials
                .FirstOrDefaultAsync(m => m.Id == id);
            if (social == null)
            {
                return NotFound();
            }

            return View(social);
        }

        // GET: admin/Socials/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: admin/Socials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Icon,Name,Link")] Social social)
        {
            if (ModelState.IsValid)
            {
                _context.Add(social);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(social);
        }

        // GET: admin/Socials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var social = await _context.Socials.FindAsync(id);
            if (social == null)
            {
                return NotFound();
            }
            return View(social);
        }

        // POST: admin/Socials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Icon,Name,Link")] Social social)
        {
            if (id != social.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(social);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SocialExists(social.Id))
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
            return View(social);
        }

        // GET: admin/Socials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var social = await _context.Socials
                .FirstOrDefaultAsync(m => m.Id == id);
            if (social == null)
            {
                return NotFound();
            }

            return View(social);
        }

        // POST: admin/Socials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var social = await _context.Socials.FindAsync(id);
            _context.Socials.Remove(social);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SocialExists(int id)
        {
            return _context.Socials.Any(e => e.Id == id);
        }
    }
}
