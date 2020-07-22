CREATE PROCEDURE [dbo].[Recipes_GetAllInCuisine]
    @StartIndex int,
	@NumberOfRows int,
    @CuisineName NVARCHAR(1000)
AS
SELECT distinct
r1.*,
STUFF((
    SELECT DISTINCT ', ' + c.Name
    FROM
            (
                SELECT Recipes.* FROM Recipes) r2
                LEFT JOIN Recipes_Cuisines ON r2.Id = Recipes_Cuisines.Recipes_Id
                LEFT JOIN (SELECT * FROM Cuisines) c ON Recipes_Cuisines.Cuisines_Id=c.Id
                WHERE r1.Id = r2.Id 
                FOR XML PATH('')), 1, 2, ''
            ) as CuisineList
FROM Recipes r1 
LEFT JOIN Recipes_Cuisines ON r1.Id = Recipes_Cuisines.Recipes_Id
LEFT JOIN (SELECT * FROM Cuisines) c2 ON Recipes_Cuisines.Cuisines_Id=c2.Id
WHERE (@CuisineName IS NULL)
or (c2.Name=@CuisineName)
ORDER by r1.Id
OFFSET @StartIndex ROWS FETCH NEXT @NumberOfRows ROWS ONLY