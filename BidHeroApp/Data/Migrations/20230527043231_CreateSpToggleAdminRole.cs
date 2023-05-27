using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BidHeroApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateSpToggleAdminRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
			-- ================================================
			-- Template generated from Template Explorer using:
			-- Create Procedure (New Menu).SQL
			--
			-- Use the Specify Values for Template Parameters 
			-- command (Ctrl-Shift-M) to fill in the parameter 
			-- values below.
			--
			-- This block of comments will not be included in
			-- the definition of the procedure.
			-- ================================================
			SET ANSI_NULLS ON
			GO
			SET QUOTED_IDENTIFIER ON
			GO
			-- =============================================
			-- Author:		Elmor Cabalfin
			-- Create date: 27-MAY-2023
			-- Description:	Add or remove Admin user's role
			-- =============================================
			CREATE PROCEDURE spToggleAdminRole
				-- Add the parameters for the stored procedure here
				@UserId [nvarchar](450)
			AS
			BEGIN
				-- SET NOCOUNT ON added to prevent extra result sets from
				-- interfering with SELECT statements.
				SET NOCOUNT ON;

				DECLARE @RoleId [nvarchar](450);
				SET @RoleId = (SELECT [Id] FROM [dbo].[AspNetRoles] WHERE [Name] = 'Administrator');

				DECLARE @Count [int];
				SET @Count = (SELECT COUNT(*) FROM [dbo].[AspNetUserRoles] WHERE [UserId] = @UserId AND [RoleId] = @RoleId);

				IF @Count > 0
					BEGIN
						DELETE [dbo].[AspNetUserRoles] WHERE [UserId] = @UserId AND [RoleId] = @RoleId
					END
				ELSE
					BEGIN
						INSERT INTO [dbo].[AspNetUserRoles] ([UserId],[RoleId]) VALUES (@UserId,@RoleId);
					END

			END
			GO
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql(@"
			USE [BidHeroApp]
			GO
			DROP PROCEDURE [dbo].[spToggleAdminRole]
			GO
			");
        }
    }
}
