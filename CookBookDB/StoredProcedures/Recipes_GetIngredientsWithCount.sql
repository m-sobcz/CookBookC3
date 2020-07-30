CREATE PROCEDURE [dbo].[Recipes_GetIngredientsWithCount]
	@Id int
AS
SELECT i.*,ri.[Count] 
FROM Ingredients i
LEFT JOIN Recipes_Ingredients ri on i.Id=ri.Ingredients_Id
WHERE ri.Recipes_Id=@Id
