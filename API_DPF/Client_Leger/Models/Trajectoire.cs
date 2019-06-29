using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Client_Leger.Models
{
    public class Trajectoire
    {
        public int Id { get; set; }

        public int Valeur { get; set; }

        public int AnneeId { get; set; }

        public int ChargeId { get; set; }

        public int OffreId { get; set; }


        public Trajectoire()
        {

        }
    }
}