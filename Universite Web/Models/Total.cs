using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Universite_Web.Models
{
    public class Total
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(150)]
        public string Icon { get; set; }
        public int Numeral { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }

    }
}
