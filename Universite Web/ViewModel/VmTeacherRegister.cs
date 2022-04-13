using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Universite_Web.Models;

namespace Universite_Web.ViewModel
{
    public class VmTeacherRegister
    {
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Surname { get; set; }
        [MaxLength(250)]
        public string AtaAdi { get; set; }
        [MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [MaxLength(30)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [MaxLength(30)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string RepaetPassword { get; set; }
        public int PassportNumber { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        [MaxLength(150)]
        public string Adress { get; set; }
        public DateTime DateOfBirth { get; set; }


        [ForeignKey("Faculty")]
        public int? FacultyId { get; set; }
        public Faculty Faculty { get; set; }
        [ForeignKey("Specialty")]
        public int? SpecialtyId { get; set; }
        public Specialty Specialty { get; set; }
        [ForeignKey("EducationSection")]
        public int? EducationSectionId { get; set; }
        public EducationSection EducationSection { get; set; }
        [ForeignKey("Group")]
        public int? GroupId { get; set; }
        public Group Groups { get; set; }
        [ForeignKey("Subject")]
        public int? SubjectId { get; set; }
        public Subject Subject { get; set; }
        [MaxLength(250)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public bool IsAdmin { get; set; } = false;
        public bool IsStudent { get; set; } = false;

    }
}
