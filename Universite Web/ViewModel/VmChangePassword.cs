using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Universite_Web.ViewModel
{
    public class VmChangePassword
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Parolu daxil edin")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Yeni Parolu daxil edin")]
        public string NewPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Yeni Parolu tesdiq edin")]
        [Compare(nameof(NewPassword))]
        public string ConfirmPassword { get; set; }
    }
}
