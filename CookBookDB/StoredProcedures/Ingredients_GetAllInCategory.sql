CREATE PROCEDURE [dbo].[Ingredients_GetAllInCategory]
    @StartIndex int,
	@NumberOfRows int,
    @CategoryName NVARCHAR(1000)
AS
SELECT distinct
i1.*,STUFF
(
        (
            SELECT DISTINCT ', ' + c.Name
            FROM
            (
                SELECT Ingredients.* FROM Ingredients) i2
                LEFT JOIN Ingredients_Categories ON i2.Id = Ingredients_Categories.Ingredients_Id
                LEFT JOIN (SELECT * FROM Categories) c ON Ingredients_Categories.Categories_Id=c.Id
                WHERE i1.Id = i2.Id 
                FOR XML PATH('')
          ), 
          1, 
          2, 
          ''
) as CategoryList
FROM Ingredients i1 
LEFT JOIN Ingredients_Categories ON i1.Id = Ingredients_Categories.Ingredients_Id
LEFT JOIN (SELECT * FROM Categories) c2 ON Ingredients_Categories.Categories_Id=c2.Id
WHERE (@CategoryName IS NULL)
or (c2.Name=@CategoryName)
ORDER by i1.Id
OFFSET @StartIndex ROWS FETCH NEXT @NumberOfRows ROWS ONLY