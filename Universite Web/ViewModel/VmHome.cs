using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Universite_Web.Models;

namespace Universite_Web.ViewModel
{
    public class VmHome
    {
        public List<Slider> Sliders { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Total> Totals { get; set; }
        public List<CustomUser> CustomUsers { get; set; }
        public UniverstyVideo UniverstyVideo { get; set; }
        public List<Partner> Partners { get; set; }
        public About About { get; set; }
        public int PageCount { get; set; }
        public double ItemCount { get; set; }
        public int Page { get; set; }

    }
}
