using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Universite_Web.Models
{
    public class SerbestIs
    {
        [Key]
        public int Id { get; set; }
        public int Qiymetlendirme { get; set; }
        public List<Dersnovu> Dersnovus { get; set; }

    }
}
