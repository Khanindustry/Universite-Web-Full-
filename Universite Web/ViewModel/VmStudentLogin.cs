using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Universite_Web.Models;

namespace Universite_Web.ViewModel
{
    public class VmStudentLogin
    {
        [MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [MaxLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsStudent { get; set; }
    }
}
