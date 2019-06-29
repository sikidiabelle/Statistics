using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Client_Leger.Models
{
    public class Detail
    {
        public int Id { get; set; }

        public string DetailCharge { get; set; }

        public int ChargeId { get; set; }

        public Detail()
        {

        }


    }
}