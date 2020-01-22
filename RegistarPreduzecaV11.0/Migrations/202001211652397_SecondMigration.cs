namespace RegistarPreduzecaV11._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Preduzeces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegNaziv = c.String(),
                        RegAdresa = c.String(),
                        Opstina = c.String(),
                        PostanskiBroj = c.Int(nullable: false),
                        MaticniBroj = c.String(),
                        PIB = c.String(),
                        SifraDelatnosti = c.Int(nullable: false),
                        OpisDelatnosti = c.String(),
                        BrojRacuna = c.String(),
                        WebStranica = c.String(),
                        Pecat = c.String(),
                        Beleska = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KontaktOsobas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Prezime = c.String(),
                        RadnoMesto = c.String(),
                        PreduzeceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Preduzeces", t => t.PreduzeceId, cascadeDelete: true)
                .Index(t => t.PreduzeceId);
            
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OznakaTipa = c.String(),
                        EmailAdresa = c.String(),
                        KontaktOsobaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KontaktOsobas", t => t.KontaktOsobaId, cascadeDelete: true)
                .Index(t => t.KontaktOsobaId);
            
            CreateTable(
                "dbo.KontaktTelefons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OznakaTipa = c.String(),
                        BrojTelefona = c.String(),
                        Lokal = c.Int(nullable: false),
                        KontaktOsobaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.KontaktOsobas", t => t.KontaktOsobaId, cascadeDelete: true)
                .Index(t => t.KontaktOsobaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.KontaktOsobas", "PreduzeceId", "dbo.Preduzeces");
            DropForeignKey("dbo.KontaktTelefons", "KontaktOsobaId", "dbo.KontaktOsobas");
            DropForeignKey("dbo.Emails", "KontaktOsobaId", "dbo.KontaktOsobas");
            DropIndex("dbo.KontaktTelefons", new[] { "KontaktOsobaId" });
            DropIndex("dbo.Emails", new[] { "KontaktOsobaId" });
            DropIndex("dbo.KontaktOsobas", new[] { "PreduzeceId" });
            DropTable("dbo.KontaktTelefons");
            DropTable("dbo.Emails");
            DropTable("dbo.KontaktOsobas");
            DropTable("dbo.Preduzeces");
        }
    }
}
