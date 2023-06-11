using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BidHeroApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSpPlaceBid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
				USE [BidHeroApp]
				GO

				/****** Object:  StoredProcedure [dbo].[spPlaceBid]    Script Date: 11/06/2023 2:27:55 pm ******/
				SET ANSI_NULLS ON
				GO

				SET QUOTED_IDENTIFIER ON
				GO


				-- =============================================
							-- Author:		Elmor Cabalfin
							-- Create date: 11-JUN-2023
							-- Description:	Place bid points
							-- =============================================
							CREATE PROCEDURE [dbo].[spPlaceBid]
								-- Add the parameters for the stored procedure here
								@UserId [nvarchar](450),
								@ItemId [int],
								@Points [int]
							AS
							BEGIN
								-- SET NOCOUNT ON added to prevent extra result sets from
								-- interfering with SELECT statements.
								SET NOCOUNT ON;

								INSERT INTO [dbo].[Bid]
									   ([Points]
									   ,[ItemId]
									   ,[IsActive]
									   ,[IsDeleted]
									   ,[CreatedByUserId])
								 VALUES
									   (@Points
									   ,@ItemId
									   ,1
									   ,0
									   ,@UserId);

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

				/****** Object:  StoredProcedure [dbo].[spPlaceBid]    Script Date: 11/06/2023 2:28:34 pm ******/
				DROP PROCEDURE [dbo].[spPlaceBid]
				GO
			");
        }
    }
}
