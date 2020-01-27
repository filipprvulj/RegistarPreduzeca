namespace RegistarPreduzecaV11._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class izmena : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Emails", "EmailAdresa", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Emails", "EmailAdresa", c => c.String());
        }
    }
}
