CREATE PROCEDURE [dbo].[Recipes_GetCuisines]
	@Id int
AS
SELECT c.* 
FROM Cuisines c
LEFT JOIN Recipes_Cuisines rc on c.Id=rc.Cuisines_Id
WHERE rc.Recipes_Id=@Id
