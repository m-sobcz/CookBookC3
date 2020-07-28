CREATE PROCEDURE [dbo].[Steps_Update]
	@Description NVarchar(1000),
	@Id int,
	@Order int,
	@Recipe_Id int
AS
INSERT INTO Steps (Description) 
VALUES (@Description)
SELECT CAST(SCOPE_IDENTITY() AS INT)