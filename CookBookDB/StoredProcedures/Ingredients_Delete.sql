CREATE PROCEDURE [dbo].[Ingredients_Delete]
	@Id int
AS
DELETE FROM Ingredients
WHERE Id=@Id