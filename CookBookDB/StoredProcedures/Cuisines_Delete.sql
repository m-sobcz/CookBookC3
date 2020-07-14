CREATE PROCEDURE [dbo].[Cuisines_Delete]
	@Id int = 0
AS
DELETE FROM Cuisines
WHERE Id=@Id