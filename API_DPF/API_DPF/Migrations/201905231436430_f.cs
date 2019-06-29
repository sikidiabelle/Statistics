namespace API_DPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Trajectoires", name: "ChargeId", newName: "CommentaireId");
            RenameIndex(table: "dbo.Trajectoires", name: "IX_ChargeId", newName: "IX_CommentaireId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Trajectoires", name: "IX_CommentaireId", newName: "IX_ChargeId");
            RenameColumn(table: "dbo.Trajectoires", name: "CommentaireId", newName: "ChargeId");
        }
    }
}
