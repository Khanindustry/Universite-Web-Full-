using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Universite_Web.Data;
using Universite_Web.Models;

namespace Universite_Web.Areas.admin.Controllers
{
    [Area("admin")]
    public class SettingsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SettingsController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: admin/Settings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Settings.ToListAsync());
        }

        // GET: admin/Settings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var settings = await _context.Settings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (settings == null)
            {
                return NotFound();
            }

            return View(settings);
        }

        // GET: admin/Settings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: admin/Settings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Settings settings)
        {
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    if (settings.ImageFile != null)
                    {
                        if (settings.ImageFile.ContentType == "image/jpeg" || settings.ImageFile.ContentType == "image/png")
                        {
                            if (settings.ImageFile.Length <= 3000000)
                            {
                                string FileName = Guid.NewGuid() + "-" + settings.ImageFile.FileName;
                                string FilePath = Path.Combine(_webHostEnvironment.WebRootPath, "UploadsSettings", FileName);
                                using (var stream = new FileStream(FilePath, FileMode.Create))
                                {
                                    settings.ImageFile.CopyTo(stream);
                                }
                                settings.Logo = FileName;
                                _context.Add(settings);
                                await _context.SaveChangesAsync();
                                return RedirectToAction(nameof(Index));

                            }
                            else
                            {
                                ModelState.AddModelError("", "you can choose only 3 mb image file");
                                return View(settings);
                            }


                        }
                        else
                        {
                            ModelState.AddModelError("", "you can choose only image file");
                            return View(settings);

                        }

                    }
                    else
                    {
                        ModelState.AddModelError("", " choose image file");
                        return View(settings);

                    }

                }
              
            }
            return View(settings);
        }

        // GET: admin/Settings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var settings = await _context.Settings.FindAsync(id);
            if (settings == null)
            {
                return NotFound();
            }
            return View(settings);
        }

        // POST: admin/Settings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Settings settings)
        {
            if (id != settings.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    if (settings.ImageFile != null)
                    {
                        if (settings.ImageFile.ContentType == "image/jpeg" || settings.ImageFile.ContentType == "image/png")
                        {
                            if (settings.ImageFile.Length <= 3000000)
                            {
                                string olddata = Path.Combine(_webHostEnvironment.WebRootPath, "UploadsSettings", settings.Logo);
                                if (System.IO.File.Exists(olddata))
                                {
                                    System.IO.File.Delete(olddata);
                                }
                                string FileName = Guid.NewGuid() + "-" + settings.ImageFile.FileName;
                                string FilePath = Path.Combine(_webHostEnvironment.WebRootPath, "UploadsSettings", FileName);
                                using (var stream = new FileStream(FilePath, FileMode.Create))
                                {
                                    settings.ImageFile.CopyTo(stream);
                                }
                                settings.Logo = FileName;
                                _context.Settings.Update(settings);
                                await _context.SaveChangesAsync();
                                return RedirectToAction(nameof(Index));

                            }
                            else
                            {
                                ModelState.AddModelError("", "you can choose only 3 mb image file");
                                return View(settings);
                            }


                        }
                        else
                        {
                            ModelState.AddModelError("", "you can choose only image file");
                            return View(settings);

                        }

                    }
                    else
                    {
                        ModelState.AddModelError("", " choose image file");
                        return View(settings);

                    }

                }
            }
            return View(settings);
        }

        // GET: admin/Settings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var settings = await _context.Settings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (settings == null)
            {
                return NotFound();
            }

            return View(settings);
        }

        // POST: admin/Settings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var settings = await _context.Settings.FindAsync(id);
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "UploadsSettings", settings.Logo);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
            _context.Settings.Remove(settings);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SettingsExists(int id)
        {
            return _context.Settings.Any(e => e.Id == id);
        }
    }
}
