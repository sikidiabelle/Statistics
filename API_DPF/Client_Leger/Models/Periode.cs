using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Client_Leger.Models
{
    public class Periode
    {
        public int Id { get; set; }

        public int Mois { get; set; }
        
        public int AnneeId { get; set; }

        public Periode()
        {

        }
    }
}