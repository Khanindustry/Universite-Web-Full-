using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Universite_Web.Models
{
    public class Dersnovu
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Muhazire")]
        public int MuhazireId { get; set; }
        public Muhazire Muhazire { get; set; }
        [ForeignKey("Seminar")]
        public int SeminarId { get; set; }
        public Seminar Seminar { get; set; }
        [ForeignKey("SerbestIs")]
        public int SerbestIsId { get; set; }
        public SerbestIs SerbestIs { get; set; }

    }
}
