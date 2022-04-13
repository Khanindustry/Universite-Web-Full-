using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Universite_Web.Models
{
    public class UniverstyVideo
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(250)]
        public string Link { get; set; }
        [MaxLength(250)]
        public string BackImg { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }

    }
}
