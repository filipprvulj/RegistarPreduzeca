namespace RegistarPreduzecaV11._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PecatRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Preduzeces", "Pecat", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Preduzeces", "Pecat", c => c.String());
        }
    }
}
