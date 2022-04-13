using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Universite_Web.Data;

namespace Universite_Web.ViewComponents
{
    public class VcContact:ViewComponent
    {
        private readonly AppDbContext _context;

        public VcContact(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            return View(_context.Settings.FirstOrDefault());
        }
    }
}
