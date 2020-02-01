namespace RegistarPreduzecaV11._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPunoImeToKontaktOsoba : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.KontaktOsobas", "PunoIme", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.KontaktOsobas", "PunoIme");
        }
    }
}
