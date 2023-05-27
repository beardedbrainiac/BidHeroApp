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
IF NOT EXISTS (SELECT 1 FROM [dbo].[AspNetRoles] WHERE [Name] IN ('Owner', 'Administrator', 'User'))
    BEGIN
        INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'3064fc34-ba70-4390-9451-b26260a1614b', N'Owner', N'OWNER', NULL);
        INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'527297e4-45e3-41b3-b3a0-9b2802d5448c', N'Administrator', N'ADMINISTRATOR', NULL);
        INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'61817a28-9bf7-4dca-97b9-9044bf6cdb79', N'User', N'USER', NULL);
    END