CREATE PROCEDURE [dbo].[Recipes_Update]
	@Name NVarchar(1000),
	@Description NVarchar(1000),
	@Id int,
	@Portions int,
	@Time int
AS
UPDATE Recipes 
SET Name=@Name, Description=@Description,Portions=@Portions,Time=@Time
WHERE Id=@Id
SELECT CAST(SCOPE_IDENTITY() AS INT)