namespace Movie_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4a869439-36d5-48ad-a5a6-09139c5d1b97', N'admin@admin.com', 0, N'AE5Schg/Cebf5jg4REQr7qyW91nMhSmGbElGN76mkhgilKKGI52QwLUbsL2vgxj70A==', N'e85e1076-1953-4301-bcc0-04a3340a968e', NULL, 0, 0, NULL, 1, 0, N'admin@admin.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4bb9387d-72e2-428f-9b58-62e1bbdc8a27', N'gentselimi7@gmail.com', 0, N'AEik6DURzRiv38+CnsTUuuTwH1sXht83ZA9uI3kcAg3WijKirEjW6SLbiYxtlpSGqA==', N'56312f55-4e2e-4a66-b946-d62a3a0f3643', NULL, 0, 0, NULL, 1, 0, N'gentselimi7@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'7c90ceaf-aada-4d11-ba91-de7d048449a0', N'guest@gmail.com', 0, N'AKAuTtyTwlGq+uj4WJ+rcr25a6qmzWaYrqT2QIwP2GfPelZltpiwS3CkViVw+IfqMA==', N'b60173d7-0fc2-48fa-a914-48315d852af7', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'0c10943c-295e-496e-83cb-daa39248c1ce', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4a869439-36d5-48ad-a5a6-09139c5d1b97', N'0c10943c-295e-496e-83cb-daa39248c1ce')

");
        }
        
        public override void Down()
        {
        }
    }
}
