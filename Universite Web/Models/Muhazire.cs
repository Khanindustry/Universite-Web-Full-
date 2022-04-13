using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Universite_Web.Models
{
    public class Muhazire
    {
        [Key]
        public int Id { get; set; }
        public bool Activity { get; set; }
        public List<Dersnovu> Dersnovus { get; set; }

    }
}
