CREATE PROCEDURE [dbo].[Recipes_GetIngredients]
	@Id int
AS
SELECT i.* 
FROM Ingredients i
LEFT JOIN Recipes_Ingredients ri on i.Id=ri.Ingredients_Id
WHERE ri.Recipes_Id=@Id
