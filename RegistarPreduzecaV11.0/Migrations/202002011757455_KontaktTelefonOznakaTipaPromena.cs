﻿namespace RegistarPreduzecaV11._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KontaktTelefonOznakaTipaPromena : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.KontaktTelefons", "OznakaTipa", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.KontaktTelefons", "OznakaTipa", c => c.String(nullable: false, maxLength: 25));
        }
    }
}
