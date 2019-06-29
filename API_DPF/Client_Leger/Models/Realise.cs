using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Client_Leger.Models
{
    public class Realise
    {
        public int Id { get; set; }
        
        public float Compta { get; set; }
        
        public int  PeriodeId { get; set; }
        
        public int OffreId { get; set; }
        
        public int ChargeId { get; set; }
        
        public Realise()
        {

        }

    }
}