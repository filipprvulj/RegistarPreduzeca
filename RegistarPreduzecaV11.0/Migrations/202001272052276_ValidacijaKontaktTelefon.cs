namespace RegistarPreduzecaV11._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidacijaKontaktTelefon : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.KontaktTelefons", "OznakaTipa", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.KontaktTelefons", "BrojTelefona", c => c.String(nullable: false));
            AlterColumn("dbo.KontaktTelefons", "Lokal", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.KontaktTelefons", "Lokal", c => c.Int(nullable: false));
            AlterColumn("dbo.KontaktTelefons", "BrojTelefona", c => c.String());
            AlterColumn("dbo.KontaktTelefons", "OznakaTipa", c => c.String());
        }
    }
}
