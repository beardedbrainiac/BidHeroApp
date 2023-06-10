-- =============================================
											-- Author:		Elmor Cabalfin
											-- Create date: 10-JUN-2023
											-- Description:	Get all items and highest bid by the provided category
											-- =============================================
											CREATE PROCEDURE [dbo].[spCategoryItems]
												-- Add the parameters for the stored procedure here
												@CategoryId [int] NULL = NULL
											AS
											BEGIN
												-- SET NOCOUNT ON added to prevent extra result sets from
												-- interfering with SELECT statements.
												SET NOCOUNT ON;

												IF @CategoryId IS NULL
													BEGIN
														SELECT c.[Id] AS [CategoryId]
															  ,c.[Name] AS [CategoryName]
															  ,i.[Id] AS [ItemId]
															  ,i.[Name] AS [ItemName]
															  ,i.[Image]
															  ,b.[Points]
														FROM [dbo].[Category] AS c
														JOIN [dbo].[Item] AS i ON c.[Id]=i.[CategoryId]
														OUTER APPLY (SELECT TOP (1) [Id]
															  ,[Points]
															  ,[ItemId]
															  ,[IsActive]
															  ,[IsDeleted]
															  ,[CreatedByUserId]
															  ,[CreatedDate]
															  ,[UpdatedByUserId]
															  ,[UpdatedDate]
															  ,[DeletedByUserId]
															  ,[DeletedDate]
														  FROM [dbo].[Bid]
														  WHERE [ItemId] = i.[Id]
														  ORDER BY [Points] DESC) AS b
													END;
												ELSE
													BEGIN
														SELECT c.[Id] AS [CategoryId]
															  ,c.[Name] AS [CategoryName]
															  ,i.[Id] AS [ItemId]
															  ,i.[Name] AS [ItemName]
															  ,i.[Image]
															  ,b.[Points]
														FROM [dbo].[Category] AS c
														JOIN [dbo].[Item] AS i ON c.[Id]=i.[CategoryId]
														OUTER APPLY (SELECT TOP (1) [Id]
															  ,[Points]
															  ,[ItemId]
															  ,[IsActive]
															  ,[IsDeleted]
															  ,[CreatedByUserId]
															  ,[CreatedDate]
															  ,[UpdatedByUserId]
															  ,[UpdatedDate]
															  ,[DeletedByUserId]
															  ,[DeletedDate]
														  FROM [dbo].[Bid]
														  WHERE [ItemId] = i.[Id]
														  ORDER BY [Points] DESC) AS b
														WHERE c.[Id]=@CategoryId;
													END;

											END