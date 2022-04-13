using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Universite_Web.Data;
using Universite_Web.Models;

namespace Universite_Web.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize]

    public class UniverstyVideosController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UniverstyVideosController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: admin/UniverstyVideos
        public async Task<IActionResult> Index()
        {
            return View(await _context.UniverstyVideos.ToListAsync());
        }

        // GET: admin/UniverstyVideos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var universtyVideo = await _context.UniverstyVideos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (universtyVideo == null)
            {
                return NotFound();
            }

            return View(universtyVideo);
        }

        // GET: admin/UniverstyVideos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: admin/UniverstyVideos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( UniverstyVideo universtyVideo)
        {
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    if (universtyVideo.ImageFile != null)
                    {
                        if (universtyVideo.ImageFile.ContentType == "image/jpeg" || universtyVideo.ImageFile.ContentType == "image/png")
                        {
                            if (universtyVideo.ImageFile.Length <= 3000000)
                            {
                                string FileName = Guid.NewGuid() + "-" + universtyVideo.ImageFile.FileName;
                                string FilePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", FileName);
                                using (var stream = new FileStream(FilePath, FileMode.Create))
                                {
                                    universtyVideo.ImageFile.CopyTo(stream);
                                }
                                universtyVideo.BackImg = FileName;
                                _context.Add(universtyVideo);
                                await _context.SaveChangesAsync();
                                return RedirectToAction(nameof(Index));

                            }
                            else
                            {
                                ModelState.AddModelError("", "you can choose only 3 mb image file");
                                return View(universtyVideo);
                            }


                        }
                        else
                        {
                            ModelState.AddModelError("", "you can choose only image file");
                            return View(universtyVideo);

                        }

                    }
                    else
                    {
                        ModelState.AddModelError("", " choose image file");
                        return View(universtyVideo);

                    }

                }

               
            }
            return View(universtyVideo);
        }

        // GET: admin/UniverstyVideos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var universtyVideo = await _context.UniverstyVideos.FindAsync(id);
            if (universtyVideo == null)
            {
                return NotFound();
            }
            return View(universtyVideo);
        }

        // POST: admin/UniverstyVideos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, UniverstyVideo universtyVideo)
        {
            if (id != universtyVideo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    if (universtyVideo.ImageFile != null)
                    {
                        if (universtyVideo.ImageFile.ContentType == "image/jpeg" || universtyVideo.ImageFile.ContentType == "image/png")
                        {
                            if (universtyVideo.ImageFile.Length <= 3000000)
                            {
                                string olddata = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", universtyVideo.BackImg);
                                if (System.IO.File.Exists(olddata))
                                {
                                    System.IO.File.Delete(olddata);
                                }
                                string FileName = Guid.NewGuid() + "-" + universtyVideo.ImageFile.FileName;
                                string FilePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", FileName);
                                using (var stream = new FileStream(FilePath, FileMode.Create))
                                {
                                    universtyVideo.ImageFile.CopyTo(stream);
                                }
                                universtyVideo.BackImg = FileName;
                                _context.UniverstyVideos.Update(universtyVideo);
                                await _context.SaveChangesAsync();
                                return RedirectToAction(nameof(Index));

                            }
                            else
                            {
                                ModelState.AddModelError("", "you can choose only 3 mb image file");
                                return View(universtyVideo);
                            }


                        }
                        else
                        {
                            ModelState.AddModelError("", "you can choose only image file");
                            return View(universtyVideo);

                        }

                    }
                    else
                    {
                        ModelState.AddModelError("", " choose image file");
                        return View(universtyVideo);

                    }

                }
            }
            return View(universtyVideo);
        }

        // GET: admin/UniverstyVideos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var universtyVideo = await _context.UniverstyVideos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (universtyVideo == null)
            {
                return NotFound();
            }

            return View(universtyVideo);
        }

        // POST: admin/UniverstyVideos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var universtyVideo = await _context.UniverstyVideos.FindAsync(id);
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", universtyVideo.BackImg);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
            _context.UniverstyVideos.Remove(universtyVideo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UniverstyVideoExists(int id)
        {
            return _context.UniverstyVideos.Any(e => e.Id == id);
        }
    }
}
