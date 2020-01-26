namespace RegistarPreduzecaV11._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'54408f3a-f7f2-43fd-b077-646a9fab6b79', N'korisnik@registar.com', 0, N'AC5GnFD71OtppCkQ6Yh72RkOECGVUc2Z+AVZM3TgDDSzVqunh1ESNHmMs8XeBNcbWg==', N'07ac2741-abda-46eb-b212-630fcd1b172f', NULL, 0, 0, NULL, 1, 0, N'korisnik@registar.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c7c2737f-dd4c-455e-914a-4ff5d89a9142', N'admin@registar.com', 0, N'AOiOsgrLkpRMGKg6Y8n24o4GYFIiiZA9/CTukK4vNFC9OwcMq4nJ+6LXwerGMocbjw==', N'4a4b469c-532c-41b6-b605-57dec84da234', NULL, 0, 0, NULL, 1, 0, N'admin@registar.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f68f6c32-a4e6-4b49-96c1-b793643fcc28', N'moderator@registar.com', 0, N'ABqGfMAXYjRTuAnopRly+C7VLFpMIWTUFMGk8JSeDcibtkJ5ao45kI9pESK/yWaxUg==', N'4aa7bb98-d397-4611-9aaa-02e0b3049fe7', NULL, 0, 0, NULL, 1, 0, N'moderator@registar.com')
                
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'49919a68-9c75-460f-b1ab-f4a5c79e865f', N'SaPravomAdministracije')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'4da17410-2ca3-47f6-92da-de189975a946', N'SaPravomPregleda')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'92bd4fa1-c32e-4490-b9d1-1a369967287b', N'SaPravomUnosa')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c7c2737f-dd4c-455e-914a-4ff5d89a9142', N'49919a68-9c75-460f-b1ab-f4a5c79e865f')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'54408f3a-f7f2-43fd-b077-646a9fab6b79', N'4da17410-2ca3-47f6-92da-de189975a946')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f68f6c32-a4e6-4b49-96c1-b793643fcc28', N'92bd4fa1-c32e-4490-b9d1-1a369967287b')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
