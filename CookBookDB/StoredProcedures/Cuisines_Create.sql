CREATE PROCEDURE [dbo].[Cuisines_Create]
	@Id int,
	@Name NVarchar(100),
	@Description NVarchar(1000)
AS
INSERT INTO Cuisines 
(Name,Description) 
VALUES (@Name, @Description)
SELECT CAST(SCOPE_IDENTITY() AS INT)