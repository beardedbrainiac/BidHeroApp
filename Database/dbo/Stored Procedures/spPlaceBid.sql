
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