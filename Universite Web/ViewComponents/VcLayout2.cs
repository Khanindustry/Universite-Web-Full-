using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Universite_Web.Data;

namespace Universite_Web.ViewComponents
{

    public class VcLayout2 : ViewComponent
    {
        private readonly AppDbContext _context;

        public VcLayout2(AppDbContext context)
        {
            _context = context;

        }
        public IViewComponentResult Invoke()
        {
            ViewModel.VmLayout model = new ViewModel.VmLayout()
            {
                settings=_context.Settings.FirstOrDefault(),
                Socials=_context.Socials.ToList()
            };
            return View(model);
        }
    }
}
