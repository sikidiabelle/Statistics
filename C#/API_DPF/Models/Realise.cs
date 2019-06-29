using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API_DPF.Models
{
    public class Realise
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public float Compta { get; set; }
        [Required]
        public int  PeriodeId { get; set; }
        [Required]
        public int OffreId { get; set; }
        [Required]
        public int ChargeId { get; set; }

        [ForeignKey("PeriodeId")]
        public virtual Periode Periode { get; set; }
        [ForeignKey("OffreId")]
        public virtual Offre Offre { get; set; }
        [ForeignKey("ChargeId")]
        public virtual Charge Charge { get; set; }
        

        public Realise()
        {

        }

    }
}