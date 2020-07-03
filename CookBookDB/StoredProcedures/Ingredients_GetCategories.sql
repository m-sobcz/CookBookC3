CREATE PROCEDURE [dbo].[Ingredients_GetCategories]
	@Id int
AS
SELECT Categories.* 
FROM Categories 
LEFT JOIN Ingredients_Categories on Categories.Id=Ingredients_Categories.Categories_Id
LEFT JOIN Ingredients on Ingredients.Id=Ingredients_Categories.Ingredients_Id
WHERE Ingredients.Id=@Id