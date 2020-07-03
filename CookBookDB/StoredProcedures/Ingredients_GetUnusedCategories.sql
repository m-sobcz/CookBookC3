CREATE PROCEDURE [dbo].[Ingredients_GetUnusedCategories]
	@Id int
AS
SELECT Categories.* 
FROM Categories 
LEFT JOIN Ingredients_Categories on Categories.Id=Ingredients_Categories.Categories_Id
except
SELECT Categories.* 
FROM Categories 
LEFT JOIN Ingredients_Categories on Categories.Id=Ingredients_Categories.Categories_Id
where Ingredients_Categories.Ingredients_Id=@Id