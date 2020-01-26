namespace RegistarPreduzecaV11._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c7c2737f-dd4c-455e-914a-4ff5d89a9142', N'admin@registar.com', 0, N'AOiOsgrLkpRMGKg6Y8n24o4GYFIiiZA9/CTukK4vNFC9OwcMq4nJ+6LXwerGMocbjw==', N'4a4b469c-532c-41b6-b605-57dec84da234', NULL, 0, 0, NULL, 1, 0, N'admin@registar.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f68f6c32-a4e6-4b49-96c1-b793643fcc28', N'moderator@registar.com', 0, N'ABqGfMAXYjRTuAnopRly+C7VLFpMIWTUFMGk8JSeDcibtkJ5ao45kI9pESK/yWaxUg==', N'4aa7bb98-d397-4611-9aaa-02e0b3049fe7', NULL, 0, 0, NULL, 1, 0, N'moderator@registar.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ff07bd7c-2391-4dcf-81c8-27f075332913', N'korisnik@registar.com', 0, N'ADm3Pe+j53yhLREEnrSdcaivIqpX/cEQPDWJkMrn7q/YpZgWo2HfXAwD3+OpR3SxPQ==', N'2b65d1c8-c072-43d3-b558-48cda6852691', NULL, 0, 0, NULL, 1, 0, N'korisnik@registar.com')
                
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'49919a68-9c75-460f-b1ab-f4a5c79e865f', N'SaPravomAdministracije')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'92bd4fa1-c32e-4490-b9d1-1a369967287b', N'SaPravomUnosa')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c7c2737f-dd4c-455e-914a-4ff5d89a9142', N'49919a68-9c75-460f-b1ab-f4a5c79e865f')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f68f6c32-a4e6-4b49-96c1-b793643fcc28', N'92bd4fa1-c32e-4490-b9d1-1a369967287b')

                ");
        }
        
        public override void Down()
        {
        }
    }
}
