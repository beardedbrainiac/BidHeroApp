/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

USE [BidHeroApp]
GO
IF NOT EXISTS (SELECT 1 FROM [dbo].[__EFMigrationsHistory] WHERE [MigrationId] IN ('00000000000000_CreateIdentitySchema'))
    BEGIN
        INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'00000000000000_CreateIdentitySchema', N'3.0.0')
        INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230527034334_UpdateUser', N'7.0.5')
        INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230527041624_CreateVwUser', N'7.0.5')
        INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230527043231_CreateSpToggleAdminRole', N'7.0.5')
        INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230602094943_CreateCategory', N'7.0.5')
    END
IF NOT EXISTS (SELECT 1 FROM [dbo].[AspNetRoles] WHERE [Name] IN ('Owner', 'Administrator', 'User'))
    BEGIN
        INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'3064fc34-ba70-4390-9451-b26260a1614b', N'Owner', N'OWNER', NULL);
        INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'527297e4-45e3-41b3-b3a0-9b2802d5448c', N'Administrator', N'ADMINISTRATOR', NULL);
        INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'61817a28-9bf7-4dca-97b9-9044bf6cdb79', N'User', N'USER', NULL);
    END
IF NOT EXISTS (SELECT 1 FROM [dbo].[AspNetUsers] WHERE [Email] = 'cabalfinelmor17@gmail.com')
    BEGIN
        INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [GivenName], [FamilyName], [Gender], [BirthDate]) VALUES (N'8ad9f390-0767-4109-aa82-b8d55fb0d22f', N'cabalfinelmor17@gmail.com', N'CABALFINELMOR17@GMAIL.COM', N'cabalfinelmor17@gmail.com', N'CABALFINELMOR17@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEOgAisVsjqV4QMh8wbJimztpXwApP0RsXx6v2xHROcoQao5CP6OeQjv7rbL7T4yOgQ==', N'C54E7OCGOC5W5AESNMS52STXG2IRFXP4', N'8d9f5433-a019-495d-8102-fb35b2e366c4', NULL, 0, 0, NULL, 1, 0, N'Elmor', N'Cabalfin', 1, CAST(N'1992-05-17' AS Date));
        INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8ad9f390-0767-4109-aa82-b8d55fb0d22f', N'3064fc34-ba70-4390-9451-b26260a1614b');
        INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8ad9f390-0767-4109-aa82-b8d55fb0d22f', N'61817a28-9bf7-4dca-97b9-9044bf6cdb79');
    END
IF NOT EXISTS (SELECT 1 FROM [dbo].[AspNetUsers] WHERE [Email] = 'admin@email.com')
    BEGIN
        INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [GivenName], [FamilyName], [Gender], [BirthDate]) VALUES (N'25b84c8e-a2a1-439a-9815-1a2e092d03dd', N'admin@email.com', N'ADMIN@EMAIL.COM', N'admin@email.com', N'ADMIN@EMAIL.COM', 1, N'AQAAAAIAAYagAAAAEKxTePMPxuOueoYU9gNs50yBu0fBeiGyRhhRYsB3QtOCHFpaWDIi49Iy+qgI9ZLrwQ==', N'RFPZRMLBHL6M4YV2YTWV3F56YLHTOY42', N'6565c7a0-a7c3-4a4a-9f67-f50baf39b47b', NULL, 0, 0, NULL, 1, 0, N'Elmor', N'Cabalfin', 1, CAST(N'1992-05-17' AS Date))
        INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'25b84c8e-a2a1-439a-9815-1a2e092d03dd', N'527297e4-45e3-41b3-b3a0-9b2802d5448c')
        INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'25b84c8e-a2a1-439a-9815-1a2e092d03dd', N'61817a28-9bf7-4dca-97b9-9044bf6cdb79')
    END
IF NOT EXISTS (SELECT 1 FROM [dbo].[Category] WHERE [Name] IN ('Electronics'))
    BEGIN
        SET IDENTITY_INSERT [dbo].[Category] ON
        INSERT [dbo].[Category] ([Id], [Name], [IsActive], [IsDeleted], [CreatedByUserId], [CreatedDate], [UpdatedByUserId], [UpdatedDate], [DeletedByUserId], [DeletedDate]) VALUES (1, N'Electronics', 1, 0, N'25b84c8e-a2a1-439a-9815-1a2e092d03dd', CAST(N'2023-06-02T09:25:08.5933333+00:00' AS DateTimeOffset), NULL, NULL, NULL, NULL)
        SET IDENTITY_INSERT [dbo].[Category] OFF
    END