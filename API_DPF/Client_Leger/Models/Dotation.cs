using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Client_Leger.Models
{
    public class Dotation
    {
        public int Id { get; set; }
        
        public float Montant { get; set; }
        
        public int AnneeId { get; set; }
        
        public int OffreId { get; set; }

        public Dotation()
        {

        }
    }
}