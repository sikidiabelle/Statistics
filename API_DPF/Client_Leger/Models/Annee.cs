using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Client_Leger.Models
{
    public class Annee
    {
        
        public int Id { get; set; }
        
        public int An { get; set; }
       
        public Boolean Courant { get; set; }

        public Annee()
        {

        }
    }
}