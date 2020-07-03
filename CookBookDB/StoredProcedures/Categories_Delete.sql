CREATE PROCEDURE [dbo].[Categories_Delete]
	@Id int = 0
AS
DELETE FROM Categories
WHERE Id=@Id