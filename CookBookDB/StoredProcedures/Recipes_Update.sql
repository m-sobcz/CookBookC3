CREATE PROCEDURE [dbo].[Recipes_Update]
	@Name NVarchar(1000),
	@Description NVarchar(1000),
	@Id int
AS
UPDATE Recipes 
SET Name=@Name, Description=@Description 
WHERE Id=@Id