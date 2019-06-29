using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API_DPF.Models
{
    public class Dotation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public float Montant { get; set; }
        [Required]
        public int AnneeId { get; set; }
        [Required]
        public int OffreId { get; set; }

        [ForeignKey("AnneeId")]
        public virtual Annee Annee { get; set; }
        [ForeignKey("OffreId")]
        public virtual Offre Offre { get; set; }
        public Dotation()
        {

        }
    }
}