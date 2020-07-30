CREATE PROCEDURE [dbo].[Ingredients_Delete]
	@Id int
AS

DELETE FROM Ingredients_Categories 
WHERE Ingredients_Categories.Ingredients_Id=@Id

DELETE FROM Recipes_Ingredients 
WHERE Recipes_Ingredients.Ingredients_Id=@Id

DELETE FROM Ingredients
WHERE Id=@Id