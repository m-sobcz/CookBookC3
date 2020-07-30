CREATE PROCEDURE [dbo].[Recipes_EditIngredientCount]
	@Recipes_Id  int,
	@Ingredients_Id int,
	@Count int
AS
UPDATE Recipes_Ingredients
SET Recipes_Ingredients.[Count]=@Count
WHERE Recipes_Ingredients.Recipes_Id=@Recipes_Id
AND Recipes_Ingredients.Ingredients_Id=@Ingredients_Id
