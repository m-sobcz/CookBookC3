CREATE PROCEDURE [dbo].[Cuisines_Delete]
	@Id int = 0
AS

DELETE FROM Recipes_Cuisines 
WHERE Recipes_Cuisines.Cuisines_Id=@Id

DELETE FROM Cuisines
WHERE Id=@Id