using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Universite_Web.Models
{
    public class Faculty
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        public List<Specialty> Specialties { get; set; }
        public List<Group> Groups { get; set; }
        public List<CustomUser> CustomUsers { get; set; }
    }
}
