CREATE PROCEDURE [dbo].[Recipes_Delete]
	@Id int
AS

DELETE FROM Recipes_Cuisines 
WHERE Recipes_Cuisines.Recipes_Id=@Id

DELETE FROM Recipes_Ingredients 
WHERE Recipes_Ingredients.Recipes_Id=@Id

DELETE FROM Recipes
WHERE Id=@Id