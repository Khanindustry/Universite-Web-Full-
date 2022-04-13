using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Universite_Web.ViewModel
{
    public class VmResetPassword
    {
        [MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

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
