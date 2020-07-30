USE [CookBook]
GO

DECLARE	@return_value Int

EXEC	@return_value = [dbo].[Recipes_GetIngredientsWithCount]
		@Id = 1

SELECT	@return_value as 'Return Value'

GO
