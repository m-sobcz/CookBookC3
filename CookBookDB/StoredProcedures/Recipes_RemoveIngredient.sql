CREATE PROCEDURE [dbo].[Recipes_RemoveIngredient]
	@Recipes_Id  int,
	@Ingredients_Id int
AS
DELETE FROM Recipes_Ingredients
WHERE Recipes_Ingredients.Recipes_Id=@Recipes_Id
AND Recipes_Ingredients.Ingredients_Id=@Ingredients_Id