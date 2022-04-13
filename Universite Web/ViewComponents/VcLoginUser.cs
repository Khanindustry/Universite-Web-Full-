using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Universite_Web.Data;
using Universite_Web.ViewModel;

namespace Universite_Web.ViewComponents
{
    public class VcLoginUser:ViewComponent
    {
        private readonly AppDbContext _context;
        public VcLoginUser(AppDbContext context)
        {
              _context = context;
        }

        public IViewComponentResult Invoke()
        {
            VmStudentLogin login = new VmStudentLogin();
             
            return View( login);
        }
    }
}
