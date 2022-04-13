using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Universite_Web.Data;
using Universite_Web.ViewModel;

namespace Universite_Web.ViewComponents
{
    public class VcLoginTeacher:ViewComponent
    {
        private readonly AppDbContext _context;
        public VcLoginTeacher(AppDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            VmTeacherLogin login = new VmTeacherLogin();

            return View(login);
        }
    }
}
