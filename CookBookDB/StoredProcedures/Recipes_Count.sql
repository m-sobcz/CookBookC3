CREATE PROCEDURE [dbo].[Recipes_Count]
@CuisineName NVARCHAR(1000)
AS
IF @CuisineName is null
SELECT COUNT(r.Id) 
FROM Recipes  r
ELSE
SELECT COUNT(r.Id) 
FROM Recipes r
LEFT JOIN Recipes_Cuisines rc ON r.Id = rc.Recipes_Id
LEFT JOIN (SELECT * FROM Cuisines) c ON rc.Cuisines_Id=c.Id
WHERE (c.Name=@CuisineName)