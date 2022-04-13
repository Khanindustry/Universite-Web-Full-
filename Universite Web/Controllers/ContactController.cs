using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Universite_Web.Data;

namespace Universite_Web.Controllers
{
    
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            return View(_context.Settings.FirstOrDefault());
        }
    }
}
