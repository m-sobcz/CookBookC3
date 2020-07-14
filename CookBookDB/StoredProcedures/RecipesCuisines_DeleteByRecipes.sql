CREATE PROCEDURE [dbo].[RecipesCuisines_DeleteByRecipes]
	@Id int = 0
AS
DELETE FROM Recipes_Cuisines 
WHERE Recipes_Cuisines.Recipes_Id=@Id
