CREATE PROCEDURE [dbo].[Categories_Create]
	@Id int,
	@Name NVarchar(100),
	@Description NVarchar(1000)
AS
INSERT INTO Categories 
(Name,Description) 
VALUES (@Name, @Description)