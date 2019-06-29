namespace API_DPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Annees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        An = c.Int(nullable: false),
                        Courant = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Charges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Commentaires",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comment = c.String(nullable: false),
                        ChargeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Charges", t => t.ChargeId, cascadeDelete: true)
                .Index(t => t.ChargeId);
            
            CreateTable(
                "dbo.Details",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DetailCharge = c.String(nullable: false),
                        ChargeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Charges", t => t.ChargeId, cascadeDelete: true)
                .Index(t => t.ChargeId);
            
            CreateTable(
                "dbo.Dotations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AnneeId = c.Int(nullable: false),
                        OffreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Annees", t => t.AnneeId, cascadeDelete: true)
                .ForeignKey("dbo.Offres", t => t.OffreId, cascadeDelete: true)
                .Index(t => t.AnneeId)
                .Index(t => t.OffreId);
            
            CreateTable(
                "dbo.Offres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nom = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Periodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mois = c.Int(nullable: false),
                        AnneeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Annees", t => t.AnneeId, cascadeDelete: true)
                .Index(t => t.AnneeId);
            
            CreateTable(
                "dbo.Realises",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Compta = c.Single(nullable: false),
                        PeriodeId = c.Int(nullable: false),
                        OffreId = c.Int(nullable: false),
                        ChargeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Charges", t => t.ChargeId, cascadeDelete: true)
                .ForeignKey("dbo.Offres", t => t.OffreId, cascadeDelete: true)
                .ForeignKey("dbo.Periodes", t => t.PeriodeId, cascadeDelete: true)
                .Index(t => t.PeriodeId)
                .Index(t => t.OffreId)
                .Index(t => t.ChargeId);
            
            CreateTable(
                "dbo.Trajectoires",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Valeur = c.Int(nullable: false),
                        AnneeId = c.Int(nullable: false),
                        ChargeId = c.Int(nullable: false),
                        OffreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Annees", t => t.AnneeId, cascadeDelete: true)
                .ForeignKey("dbo.Charges", t => t.ChargeId, cascadeDelete: true)
                .ForeignKey("dbo.Offres", t => t.OffreId, cascadeDelete: true)
                .Index(t => t.AnneeId)
                .Index(t => t.ChargeId)
                .Index(t => t.OffreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trajectoires", "OffreId", "dbo.Offres");
            DropForeignKey("dbo.Trajectoires", "ChargeId", "dbo.Charges");
            DropForeignKey("dbo.Trajectoires", "AnneeId", "dbo.Annees");
            DropForeignKey("dbo.Realises", "PeriodeId", "dbo.Periodes");
            DropForeignKey("dbo.Realises", "OffreId", "dbo.Offres");
            DropForeignKey("dbo.Realises", "ChargeId", "dbo.Charges");
            DropForeignKey("dbo.Periodes", "AnneeId", "dbo.Annees");
            DropForeignKey("dbo.Dotations", "OffreId", "dbo.Offres");
            DropForeignKey("dbo.Dotations", "AnneeId", "dbo.Annees");
            DropForeignKey("dbo.Details", "ChargeId", "dbo.Charges");
            DropForeignKey("dbo.Commentaires", "ChargeId", "dbo.Charges");
            DropIndex("dbo.Trajectoires", new[] { "OffreId" });
            DropIndex("dbo.Trajectoires", new[] { "ChargeId" });
            DropIndex("dbo.Trajectoires", new[] { "AnneeId" });
            DropIndex("dbo.Realises", new[] { "ChargeId" });
            DropIndex("dbo.Realises", new[] { "OffreId" });
            DropIndex("dbo.Realises", new[] { "PeriodeId" });
            DropIndex("dbo.Periodes", new[] { "AnneeId" });
            DropIndex("dbo.Dotations", new[] { "OffreId" });
            DropIndex("dbo.Dotations", new[] { "AnneeId" });
            DropIndex("dbo.Details", new[] { "ChargeId" });
            DropIndex("dbo.Commentaires", new[] { "ChargeId" });
            DropTable("dbo.Trajectoires");
            DropTable("dbo.Realises");
            DropTable("dbo.Periodes");
            DropTable("dbo.Offres");
            DropTable("dbo.Dotations");
            DropTable("dbo.Details");
            DropTable("dbo.Commentaires");
            DropTable("dbo.Charges");
            DropTable("dbo.Annees");
        }
    }
}
