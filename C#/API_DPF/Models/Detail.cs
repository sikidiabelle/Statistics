using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API_DPF.Models
{
    public class Detail
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string DetailCharge { get; set; }
        [Required]
        public int ChargeId { get; set; }

        [ForeignKey("ChargeId")]
        public virtual Charge Charge { get; set; }

        public Detail()
        {

        }


    }
}