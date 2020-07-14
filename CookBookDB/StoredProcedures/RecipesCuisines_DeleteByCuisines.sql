CREATE PROCEDURE [dbo].[RecipesCuisines_DeleteByCuisines]
	@Id int = 0
AS
DELETE FROM Recipes_Cuisines 
WHERE Recipes_Cuisines.Cuisines_Id=@Id