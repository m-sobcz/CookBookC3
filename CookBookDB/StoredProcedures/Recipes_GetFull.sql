CREATE PROCEDURE [dbo].[Recipes_GetFull]
	@Id int
AS
SELECT r.*, 
i.Name as [Ingredients.Name]
FROM Recipes r
JOIN Recipes_Ingredients ri on ri.Recipes_Id=r.Id
JOIN Ingredients i on i.Id=ri.Ingredients_Id
JOIN Steps s on s.Recipe_Id=r.Id
JOIN Recipes_Cuisines rc on rc.Recipes_Id=r.Id
JOIN Cuisines c on c.Id=rc.Cuisines_Id
WHERE r.Id=@Id

