CREATE PROCEDURE [dbo].[Categories_Delete]
	@Id int = 0
AS
DELETE FROM Ingredients_Categories 
WHERE Ingredients_Categories.Categories_Id=@Id

DELETE FROM Categories
WHERE Id=@Id