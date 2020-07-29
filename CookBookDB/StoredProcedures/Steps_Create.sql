CREATE PROCEDURE [dbo].[Steps_Create]
	@Description NVarchar(1000),
	@Id int,
	@Order int,
	@Recipe_Id int
AS

INSERT INTO Steps (Description,Recipe_Id,[Order]) 
VALUES (@Description, @Recipe_Id,
(
	SELECT COALESCE(MAX(s.[Order]+1),1)  
	FROM Steps s
	WHERE Recipe_Id=@Recipe_Id)
)
SELECT @Recipe_Id