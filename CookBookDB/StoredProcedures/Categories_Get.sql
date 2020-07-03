CREATE PROCEDURE Categories_Get
	@Id int
AS
SELECT * 
FROM Categories
WHERE Categories.Id=@Id

