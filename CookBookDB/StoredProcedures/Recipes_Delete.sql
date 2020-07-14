CREATE PROCEDURE [dbo].[Recipes_Delete]
	@Id int
AS
DELETE FROM Recipes
WHERE Id=@Id