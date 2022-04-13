using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Universite_Web.Data;
using Universite_Web.Models;
using Universite_Web.ViewModel;

namespace Universite_Web.ViewComponents
{
    public class VcFenn:ViewComponent
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public VcFenn(AppDbContext context, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IViewComponentResult> InvokeAsync( )
        {
            var sagol = _userManager.GetUserId((System.Security.Claims.ClaimsPrincipal)User);
            
            Users users = new Users()
            {
                CustomUsers = _context.CustomUser.Where(m => m.Id == sagol).ToList()
            };

            var grup =  _context.Subject.Include(s => s.Group).Where(m => m.GroupId == users.CustomUsers.Select(m=>m.GroupId).FirstOrDefault()).ToList();

            return View(grup);


        }
    }
}
