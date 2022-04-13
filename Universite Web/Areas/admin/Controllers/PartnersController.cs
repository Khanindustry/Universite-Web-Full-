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
    public class PartnersController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public PartnersController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;

        }

        // GET: admin/Partners
        public async Task<IActionResult> Index()
        {
            return View(await _context.Partners.ToListAsync());
        }

        // GET: admin/Partners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partner = await _context.Partners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partner == null)
            {
                return NotFound();
            }

            return View(partner);
        }

        // GET: admin/Partners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: admin/Partners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( Partner partner)
        {
            if (ModelState.IsValid)
            {

                if (ModelState.IsValid)
                {
                    if (partner.ImageFile != null)
                    {
                        if (partner.ImageFile.ContentType == "image/jpeg" || partner.ImageFile.ContentType == "image/png")
                        {
                            if (partner.ImageFile.Length <= 3000000)
                            {
                                string FileName = Guid.NewGuid() + "-" + partner.ImageFile.FileName;
                                string FilePath = Path.Combine(_webHostEnvironment.WebRootPath, "UploadsPatners", FileName);
                                using (var stream = new FileStream(FilePath, FileMode.Create))
                                {
                                    partner.ImageFile.CopyTo(stream);
                                }
                                partner.Image = FileName;
                                _context.Add(partner);
                                await _context.SaveChangesAsync();
                                return RedirectToAction(nameof(Index));

                            }
                            else
                            {
                                ModelState.AddModelError("", "you can choose only 3 mb image file");
                                return View(partner);
                            }


                        }
                        else
                        {
                            ModelState.AddModelError("", "you can choose only image file");
                            return View(partner);

                        }

                    }
                    else
                    {
                        ModelState.AddModelError("", " choose image file");
                        return View(partner);

                    }

                }
              
            }
            return View(partner);
        }

        // GET: admin/Partners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partner = await _context.Partners.FindAsync(id);
            if (partner == null)
            {
                return NotFound();
            }
            return View(partner);
        }

        // POST: admin/Partners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Partner partner)
        {
            if (id != partner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    if (partner.ImageFile != null)
                    {
                        if (partner.ImageFile.ContentType == "image/jpeg" || partner.ImageFile.ContentType == "image/png")
                        {
                            if (partner.ImageFile.Length <= 3000000)
                            {
                                string olddata = Path.Combine(_webHostEnvironment.WebRootPath, "UploadsPatners", partner.Image);
                                if (System.IO.File.Exists(olddata))
                                {
                                    System.IO.File.Delete(olddata);
                                }
                                string FileName = Guid.NewGuid() + "-" + partner.ImageFile.FileName;
                                string FilePath = Path.Combine(_webHostEnvironment.WebRootPath, "UploadsPatners", FileName);
                                using (var stream = new FileStream(FilePath, FileMode.Create))
                                {
                                    partner.ImageFile.CopyTo(stream);
                                }
                                partner.Image = FileName;
                                _context.Partners.Update(partner);
                                await _context.SaveChangesAsync();
                                return RedirectToAction(nameof(Index));

                            }
                            else
                            {
                                ModelState.AddModelError("", "you can choose only 3 mb image file");
                                return View(partner);
                            }


                        }
                        else
                        {
                            ModelState.AddModelError("", "you can choose only image file");
                            return View(partner);

                        }

                    }
                    else
                    {
                        ModelState.AddModelError("", " choose image file");
                        return View(partner);

                    }

                }
            }
            return View(partner);
        }

        // GET: admin/Partners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partner = await _context.Partners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partner == null)
            {
                return NotFound();
            }

            return View(partner);
        }

        // POST: admin/Partners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var partner = await _context.Partners.FindAsync(id);
            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "UploadsPatners", partner.Image);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
            _context.Partners.Remove(partner);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartnerExists(int id)
        {
            return _context.Partners.Any(e => e.Id == id);
        }
    }
}
