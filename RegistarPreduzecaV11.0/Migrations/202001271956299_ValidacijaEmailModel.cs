namespace RegistarPreduzecaV11._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidacijaEmailModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Emails", "OznakaTipa", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Emails", "OznakaTipa", c => c.String());
        }
    }
}
