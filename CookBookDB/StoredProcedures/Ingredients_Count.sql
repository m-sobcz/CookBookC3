CREATE PROCEDURE [dbo].[Ingredients_Count]
@CategoryName NVARCHAR(1000)
AS
IF @CategoryName is null
SELECT COUNT(i.Id) 
FROM Ingredients i
ELSE
SELECT DISTINCT COUNT(i.Id) 
FROM Ingredients i
INNER JOIN Ingredients_Categories ic ON i.Id = ic.Ingredients_Id
INNER JOIN (SELECT * FROM Categories) c ON ic.Categories_Id=c.Id
WHERE (c.Name=@CategoryName)