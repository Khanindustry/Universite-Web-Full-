using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Universite_Web.Data;
using Universite_Web.Models;
using Universite_Web.ViewModel;

namespace Universite_Web.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize]

    public class AccountTeacherController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AccountTeacherController(AppDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Register()
        {
            ViewBag.FacultyList = _context.Faculties.ToList();
            //ViewData["SubjectId"] = new SelectList(_context.Subject, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(VmTeacherRegister model)
        {
            if (ModelState.IsValid)
            {
                if (ModelState.IsValid)
                {
                    if (model.ImageFile != null)
                    {
                        if (model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/png")
                        {
                            if (model.ImageFile.Length <= 3000000)
                            {
                                string FileName = Guid.NewGuid() + "-" + model.ImageFile.FileName;
                                string FilePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploadss", FileName);
                                using (var stream = new FileStream(FilePath, FileMode.Create))
                                {
                                    model.ImageFile.CopyTo(stream);
                                }
                                model.Image = FileName;


                            }
                            else
                            {
                                ModelState.AddModelError("", "you can choose only 3 mb image file");
                                return View(model);
                            }


                        }
                        else
                        {
                            ModelState.AddModelError("", "you can choose only image file");
                            return View(model);

                        }

                    }
                    else
                    {
                        ModelState.AddModelError("", " choose image file");
                        return View(model);

                    }

                }

                CustomUser user = new CustomUser()
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    Email = model.Email,
                    UserName = model.Email,
                    PhoneNumber = model.Phone,
                    Adress = model.Adress,
                    AtaAdi = model.AtaAdi,
                    PassportNumber = model.PassportNumber,
                    Gender = model.Gender,
                    DateOfBirth = model.DateOfBirth,
                    Image = model.Image,
                    FacultyId = model.FacultyId,
                    SpecialtyId = model.SpecialtyId,
                    EducationSectionId = (int?)model.EducationSectionId,
                    GroupId = (int?)model.GroupId,
                    SubjectId= (int?)model.SubjectId,
                    IsAdmin = model.IsAdmin,
                    IsStudent = model.IsStudent
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("index", "home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);
                }
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.FacultyList = _context.Faculties.ToList();
            //ViewData["SubjectId"] = new SelectList(_context.Subject, "Id", "Name");
            return View(model);
        }

        public JsonResult GetSubject(int specialtyId)
        {
            
            var data = _context.Subject.Where(x => x.SpecialtyId == specialtyId).ToList().FirstOrDefault();
            return Json(data);
        }
        public IActionResult Index()
        {
            return View();
        }
       
    }
}
