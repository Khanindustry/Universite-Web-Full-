using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Universite_Web.Data;
using Universite_Web.ViewModel;

namespace Universite_Web.ViewComponents
{
    public class VcLayout:ViewComponent
    {
        private readonly AppDbContext _context;

        public VcLayout(AppDbContext context)
        {
            _context = context;
            
        }

        public IViewComponentResult Invoke()
        {
            VmLayout VmLayout = new VmLayout()
            {
                settings = _context.Settings.FirstOrDefault(),
                Socials = _context.Socials.ToList()
            };
            return View(VmLayout);
        }
    }
}
