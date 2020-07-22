USE [CookBook]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[Ingredients_Count]
		@CategoryName = null

SELECT	@return_value as 'Return Value'

GO
