using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Universite_Web.Data;
using Universite_Web.Models;
using Universite_Web.ViewModel;

namespace Universite_Web.Areas.admin.Controllers
{
    [Area("admin")]
   

    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountController(AppDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(VmRegister model)
        {
            if (ModelState.IsValid)
            {
                CustomUser user = new CustomUser()
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    Email = model.Email,
                    UserName = model.Email,
                    FacultyId = (int?)model.FacultyId,
                    SpecialtyId = (int?)model.SpecialtyId,
                    EducationSectionId = (int?)model.EducationSectionId,
                    GroupId = (int?)model.GroupId,
                    SubjectId= (int?)model.SubjectId,
                    IsAdmin=model.IsAdmin
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
            }
            return View(model);
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost,AllowAnonymous]
        public async Task<IActionResult> Login(VmLogin model)
        {
            var yoxla = _context.CustomUser.Where(m => m.Email == model.Email).Select(i => i.IsAdmin).FirstOrDefault();
                    if (yoxla==true)
                    {
                        var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

                        if (result.Succeeded)
                        {
                            return RedirectToAction("index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError("", "Email or password is not valid");
                            return View(model);
                        }
                    }
                    else
                    {
                        return NotFound();
                    }

            return View(model);

        }


        public IActionResult ResetPassword()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

    }
}
