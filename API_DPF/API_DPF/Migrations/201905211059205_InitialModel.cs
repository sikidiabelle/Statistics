namespace API_DPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dotations", "Montant", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dotations", "Montant");
        }
    }
}
