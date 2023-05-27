using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BidHeroApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateVwUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                CREATE VIEW [dbo].[vwUsers] AS

                SELECT u.[Id]
                      ,u.[GivenName]
                      ,u.[FamilyName]
                      ,u.[Email]
	                  ,CAST((CASE WHEN ua.[UserId] IS NULL THEN 0 ELSE 1 END) AS BIT) AS [IsAdmin]
                  FROM [dbo].[AspNetUsers] AS u
                  LEFT JOIN (SELECT ur.[UserId]
	                FROM [dbo].[AspNetUserRoles] AS ur
	                JOIN [dbo].[AspNetRoles] AS r ON ur.[RoleId]=r.[Id]
	                WHERE r.[Name]='Administrator') AS ua ON u.[Id]=ua.[UserId]
                  LEFT JOIN (SELECT ur.[UserId]
	                FROM [dbo].[AspNetUserRoles] AS ur
	                JOIN [dbo].[AspNetRoles] AS r ON ur.[RoleId]=r.[Id]
	                WHERE r.[Name]='Owner') AS uo ON u.[Id]=uo.[UserId]
                  WHERE uo.[UserId] IS NULL
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                USE [BidHeroApp]
                GO
                DROP VIEW [dbo].[vwUsers]
                GO
            ");
        }
    }
}
