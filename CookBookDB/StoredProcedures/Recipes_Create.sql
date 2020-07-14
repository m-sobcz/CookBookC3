CREATE PROCEDURE [dbo].[Recipes_Create]
	@Id int,
	@Name NVarchar(100),
	@Description NVarchar(1000)
AS
INSERT INTO Recipes 
(Name,Description) 
VALUES (@Name, @Description)