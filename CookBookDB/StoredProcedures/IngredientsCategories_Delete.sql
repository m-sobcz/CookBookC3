CREATE PROCEDURE [dbo].[IngredientsCategories_Delete]
	@Id int = 0
AS
DELETE FROM Ingredients_Categories 
WHERE Ingredients_Categories.Categories_Id=@Id