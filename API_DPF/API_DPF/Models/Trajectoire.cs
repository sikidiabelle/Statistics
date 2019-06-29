using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API_DPF.Models
{
    public class Trajectoire
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Valeur { get; set; }
        [Required]
        public int AnneeId { get; set; }
        [Required]
        public int CommentaireId { get; set; }
        [Required]
        public int OffreId { get; set; }

        [ForeignKey("AnneeId")]
        public virtual Annee Annee { get; set; }

        [ForeignKey("OffreId")]
        public virtual Offre Offre { get; set; }

        [ForeignKey("CommentaireId")]
        public virtual Charge Charge { get; set; }

        public Trajectoire()
        {

        }
    }
}