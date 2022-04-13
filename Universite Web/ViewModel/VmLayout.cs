using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Universite_Web.Models;

namespace Universite_Web.ViewModel
{
    public class VmLayout
    {
        public Settings settings { get; set; }
        public List<Social> Socials { get; set; }
    }
}
