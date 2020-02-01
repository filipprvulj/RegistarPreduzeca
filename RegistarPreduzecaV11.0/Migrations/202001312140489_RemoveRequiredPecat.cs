namespace RegistarPreduzecaV11._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRequiredPecat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Preduzeces", "Pecat", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Preduzeces", "Pecat", c => c.String(nullable: false));
        }
    }
}
