using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API_DPF.Models
{
    public class Periode
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Mois { get; set; }
        
        [Required]
        public int AnneeId { get; set; }

        [ForeignKey("AnneeId")]
        public virtual Annee Annee { get; set; }

        public Periode()
        {

        }
    }
}