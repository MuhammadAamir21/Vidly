namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedsUsers : DbMigration
    {
        public override void Up()
        {
            //Asp.Net Users
            //Asp.Net Roles
            //Asp,Net UserRoles bridge table
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'788e0c63-c784-4da9-bef6-b85a654b8ef1', N'admin@vidly.com', 0, N'ABfjWQCsc4haWnhSa/OWTpI9J1NJs1VOTklNESn61axQqVKqko/p662EiRVDoZ3Pgw==', N'717914f8-2a23-4133-85ca-0c1f7060617a', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8e14581a-4fe0-40b2-a402-c3fb6c3c3e87', N'guest@vidly.com', 0, N'AIU8rJBjyfodmcWIiJAC9JBP+aP8ebe5Tg0WPCeMvvkfSuDsHX1LdPicbV3tZ3g8Cw==', N'753e28f6-aa5e-4ed7-99d8-65548d64d79e', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

                  INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'09b37b16-c795-4fec-97f7-867980bb44ab', N'CanManageMovies')

                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'788e0c63-c784-4da9-bef6-b85a654b8ef1', N'09b37b16-c795-4fec-97f7-867980bb44ab')

                 ");
        }

        public override void Down()
        {
        }
    }
}