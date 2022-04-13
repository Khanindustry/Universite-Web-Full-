using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Universite_Web.Models
{
    public class Seminar
    {
        public int Id { get; set; }
        public bool Activty { get; set; }
        public int Qiymetlendirme { get; set; }
        public List<Dersnovu> Dersnovus { get; set; }

    }
}
