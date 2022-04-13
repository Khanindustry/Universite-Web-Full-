using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Universite_Web.Data;
using Universite_Web.ViewModel;

namespace Universite_Web.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;

        public AboutController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            VmHome model = new VmHome()
            {
                Totals = _context.Totals.ToList(),
                About = _context.Abouts.FirstOrDefault()
            };

            return View(model);
        }
    }
}
