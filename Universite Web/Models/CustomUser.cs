using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Universite_Web.Models
{
    public class CustomUser:IdentityUser
    {
        [MaxLength(250)]
        public string Surname { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string AtaAdi { get; set; }
        public int PassportNumber { get; set; }
        public string Gender { get; set; }
        public string Money { get; set; }
        [MaxLength(20)]
        public string Phone { get; set; }
        [MaxLength(150)]
        public string Adress { get; set; }
        public string FormEducation { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? AdmissionDate { get; set; }
        public DateTime? DateOfCompletion { get; set; }
        [MaxLength(250)]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

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
        public Group Group { get; set; }
        [ForeignKey("Subject")]
        public int? SubjectId { get; set; }
        public Subject Subject { get; set; }
        public bool IsAdmin{ get; set; }
        public bool IsStudent { get; set; }

    }
}
