CREATE PROCEDURE [dbo].[Recipes_Create]
	@Id int,
	@Name NVarchar(100),
	@Description NVarchar(1000),
	@Portions int,
	@Time int
AS
INSERT INTO Recipes 
(Name,Description,Portions,Time) 
VALUES (@Name, @Description,@Portions,@Time)
SELECT CAST(SCOPE_IDENTITY() AS INT)