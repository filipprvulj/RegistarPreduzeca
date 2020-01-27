namespace RegistarPreduzecaV11._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidacijaKontaktOsoba : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.KontaktOsobas", "Ime", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.KontaktOsobas", "Prezime", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.KontaktOsobas", "RadnoMesto", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.KontaktOsobas", "RadnoMesto", c => c.String());
            AlterColumn("dbo.KontaktOsobas", "Prezime", c => c.String());
            AlterColumn("dbo.KontaktOsobas", "Ime", c => c.String());
        }
    }
}
