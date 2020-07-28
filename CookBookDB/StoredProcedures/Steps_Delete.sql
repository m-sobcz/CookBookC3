CREATE PROCEDURE [dbo].[Steps_Delete]
	@Id int
AS
DELETE FROM Steps
WHERE Steps.Id=@Id