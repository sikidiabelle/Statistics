namespace API_DPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Dotations", "Montant", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Dotations", "Montant", c => c.Single(nullable: false));
        }
    }
}
