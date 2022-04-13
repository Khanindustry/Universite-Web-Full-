using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

    public class AccountUserController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AccountUserController(AppDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _webHostEnvironment = webHostEnvironment;
        }
       

        public IActionResult Register()
        {
            ViewData["EducationSectionId"] = new SelectList(_context.EducationSections, "Id", "Country");
            //ViewData["FacultyId"] = new SelectList(_context.Faculties, "Id", "Name");
            //ViewData["SpecialtyId"] = new SelectList(_context.Specialty, "Id", "Name");
            ViewBag.FacultyList = _context.Faculties.ToList();
            //ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Name");
            return View();
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

        [HttpPost]
        public async Task<IActionResult> Register(VmStudentRegister model)
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
                    AtaAdi=model.AtaAdi,
                    PassportNumber=model.PassportNumber,
                    Gender=model.Gender,
                    Money=model.Money,
                    FormEducation=model.FormEducation,
                    DateOfBirth= model.DateOfBirth,
                    AdmissionDate= model.AdmissionDate,
                    DateOfCompletion= model.DateOfCompletion,
                    Image=model.Image,
                    FacultyId=model.FacultyId,
                    SpecialtyId=model.SpecialtyId,
                    EducationSectionId=model.EducationSectionId,
                    GroupId=model.GroupId,
                    SubjectId = (int?)model.SubjectId,
                    IsAdmin = model.IsAdmin,
                    IsStudent=model.IsStudent
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
            ViewData["GroupId"] = new SelectList(_context.Groups, "Id", "Name");
            ViewData["EducationSectionId"] = new SelectList(_context.EducationSections, "Id", "Country");


            return View(model);
        }
        
    }
}

