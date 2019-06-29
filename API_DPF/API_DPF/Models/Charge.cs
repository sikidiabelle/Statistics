using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API_DPF.Models
{
    public class Charge
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        
        public Charge()
        {

        }
    }
}