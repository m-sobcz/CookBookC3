CREATE PROCEDURE [dbo].[Cuisines_Update]
	@Name NVarchar(1000),
	@Description NVarchar(1000),
	@Id int
AS
UPDATE Cuisines 
SET Name=@Name, Description=@Description 
WHERE Id=@Id
SELECT CAST(SCOPE_IDENTITY() AS INT)