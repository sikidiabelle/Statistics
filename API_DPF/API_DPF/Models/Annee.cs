using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API_DPF.Models
{
    public class Annee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int An { get; set; }
        [Required]
        public Boolean Courant { get; set; }

        public Annee()
        {

        }
    }
}