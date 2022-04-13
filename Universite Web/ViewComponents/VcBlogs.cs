using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Universite_Web.Data;

namespace Universite_Web.ViewComponents
{
    public class VcBlogs:ViewComponent
    {
        private readonly AppDbContext _context;

        public VcBlogs(AppDbContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            return View(_context.Blogs.ToList());
        }
    }
}
