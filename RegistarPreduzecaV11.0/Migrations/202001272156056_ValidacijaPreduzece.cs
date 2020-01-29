namespace RegistarPreduzecaV11._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidacijaPreduzece : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Preduzeces", "RegNaziv", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Preduzeces", "RegAdresa", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Preduzeces", "Opstina", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Preduzeces", "MaticniBroj", c => c.String(nullable: false));
            AlterColumn("dbo.Preduzeces", "PIB", c => c.String(nullable: false));
            AlterColumn("dbo.Preduzeces", "OpisDelatnosti", c => c.String(nullable: false, maxLength: 80));
            AlterColumn("dbo.Preduzeces", "BrojRacuna", c => c.String(nullable: false));
            AlterColumn("dbo.Preduzeces", "WebStranica", c => c.String(maxLength: 255));
            AlterColumn("dbo.Preduzeces", "Beleska", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Preduzeces", "Beleska", c => c.String());
            AlterColumn("dbo.Preduzeces", "WebStranica", c => c.String());
            AlterColumn("dbo.Preduzeces", "BrojRacuna", c => c.String());
            AlterColumn("dbo.Preduzeces", "OpisDelatnosti", c => c.String());
            AlterColumn("dbo.Preduzeces", "PIB", c => c.String());
            AlterColumn("dbo.Preduzeces", "MaticniBroj", c => c.String());
            AlterColumn("dbo.Preduzeces", "Opstina", c => c.String());
            AlterColumn("dbo.Preduzeces", "RegAdresa", c => c.String());
            AlterColumn("dbo.Preduzeces", "RegNaziv", c => c.String());
        }
    }
}
