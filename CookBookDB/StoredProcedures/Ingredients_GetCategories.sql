CREATE PROCEDURE [dbo].[Ingredients_GetCategories]
	@Id int
AS
SELECT c.* 
FROM Categories c
LEFT JOIN Ingredients_Categories ic on c.Id=ic.Categories_Id
WHERE ic.Ingredients_Id=@Id