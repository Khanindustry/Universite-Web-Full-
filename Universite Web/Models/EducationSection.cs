using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Universite_Web.Models
{
    public class EducationSection
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(150)]
        public string Country { get; set; }
        public List<CustomUser> CustomUsers { get; set; }

    }
}
