CREATE PROCEDURE [dbo].[Steps_Update]
	@Description NVarchar(1000),
	@Id int,
	@Order int,
	@Recipe_Id int
AS
declare @ExtractedRecipeId int

SET @ExtractedRecipeId=(
SELECT Steps.Recipe_Id
FROM Steps
WHERE Id=@Id
)

UPDATE Steps
SET Description=@Description
WHERE Id=@Id

SELECT @ExtractedRecipeId