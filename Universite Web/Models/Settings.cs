using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Universite_Web.Models
{
    public class Settings
    {
        [Key]
        public int  Id { get; set; }
        [MaxLength(250)]
        public string Logo { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [MaxLength(250)]
        public string Adress { get; set; }
        [MaxLength(250)]
        public string Phone { get; set; }
        [MaxLength(250)]
        public string Email { get; set; }
        [MaxLength(700)]
        public string MapLink { get; set; }

    }
}
