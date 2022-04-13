using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Universite_Web.Data;
using Universite_Web.Models;
using Universite_Web.ViewModel;

namespace Universite_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _contex;

        public HomeController(AppDbContext contex)
        {
            _contex = contex;
        }
        public IActionResult Index()
        {
            VmHome home = new VmHome()
            {
                Sliders=_contex.Sliders.ToList(),
                Blogs=_contex.Blogs.ToList(),
                Totals=_contex.Totals.ToList(),
                CustomUsers=_contex.CustomUser.ToList(),
                Partners=_contex.Partners.ToList(),
                UniverstyVideo=_contex.UniverstyVideos.FirstOrDefault(),
                About=_contex.Abouts.FirstOrDefault()
            };

            return View(home);
        }
       
    }
}
