CREATE PROCEDURE [dbo].[IngredientsCategories_DeleteByIngredients]
	@Id int = 0
AS
DELETE FROM Ingredients_Categories 
WHERE Ingredients_Categories.Ingredients_Id=@Id
