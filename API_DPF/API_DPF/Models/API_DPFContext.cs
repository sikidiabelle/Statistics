using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace API_DPF.Models
{
    public class API_DPFContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public API_DPFContext() : base("name=API_DPFContext")
        {
        }

        public System.Data.Entity.DbSet<API_DPF.Models.Annee> Annees { get; set; }

        public System.Data.Entity.DbSet<API_DPF.Models.Charge> Charges { get; set; }

        public System.Data.Entity.DbSet<API_DPF.Models.Periode> Periodes { get; set; }

        public System.Data.Entity.DbSet<API_DPF.Models.Offre> Offres { get; set; }

        public System.Data.Entity.DbSet<API_DPF.Models.Dotation> Dotations { get; set; }

        public System.Data.Entity.DbSet<API_DPF.Models.Detail> Details { get; set; }

        public System.Data.Entity.DbSet<API_DPF.Models.Commentaire> Commentaires { get; set; }

        public System.Data.Entity.DbSet<API_DPF.Models.Trajectoire> Trajectoires { get; set; }

        public System.Data.Entity.DbSet<API_DPF.Models.Realise> Realises { get; set; }
    }
}
