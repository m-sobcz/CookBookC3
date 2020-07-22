CREATE PROCEDURE [dbo].[Categories_Update]
	@Name NVarchar(1000),
	@Description NVarchar(1000),
	@Id int
AS
UPDATE Categories 
SET Name=@Name, Description=@Description 
WHERE Id=@Id
SELECT CAST(SCOPE_IDENTITY() AS INT)