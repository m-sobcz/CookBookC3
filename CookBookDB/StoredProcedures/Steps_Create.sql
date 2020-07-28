CREATE PROCEDURE [dbo].[Steps_Create]
	@Description NVarchar(1000),
	@Id int,
	@Order int,
	@Recipe_Id int
AS
INSERT INTO Steps (Description,[Order],Recipe_Id) 
VALUES (@Description, @Order,
(
	SELECT COALESCE(MAX(s.Recipe_Id),1)  
	FROM Steps s
	WHERE Recipe_Id=@Recipe_Id)
)
SELECT CAST(SCOPE_IDENTITY() AS INT)