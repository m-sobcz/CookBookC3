CREATE PROCEDURE [dbo].[Recipes_GetUnusedCuisines]
	@Id int
AS
SELECT Cuisines.* 
FROM Cuisines 
except
SELECT c.* 
FROM Cuisines c 
LEFT JOIN Recipes_Cuisines rc on c.Id=rc.Cuisines_Id
where rc.Recipes_Id=@Id


