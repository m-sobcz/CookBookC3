CREATE PROCEDURE [dbo].[Ingredients_Count]
@CategoryName NVARCHAR(1000)
AS
SELECT COUNT(i.Id) 
FROM Ingredients i
LEFT JOIN Ingredients_Categories ic ON i.Id = ic.Ingredients_Id
LEFT JOIN (SELECT * FROM Categories) c ON ic.Categories_Id=c.Id
WHERE (c.Name=@CategoryName)
or (@CategoryName IS NULL)
