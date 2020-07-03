CREATE PROCEDURE [dbo].[Ingredients_RemoveCategory]
	@Ingredients_Id  int,
	@Categories_Id int
AS
DELETE FROM Ingredients_Categories
WHERE Ingredients_Categories.Ingredients_Id=@Ingredients_Id 
AND Ingredients_Categories.Categories_Id=@Categories_Id