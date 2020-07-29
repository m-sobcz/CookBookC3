CREATE PROCEDURE [dbo].[Steps_Delete]
	@Id int
AS

declare @RecipeId int
declare @Order int

set @RecipeId=(
SELECT Steps.Recipe_Id
FROM Steps
WHERE Id=@Id
)

set @Order=(
SELECT MAX(Steps.[Order])
FROM Steps
WHERE Id=@Id
)

UPDATE Steps
SET [Order]=[Order]-1
WHERE Recipe_Id=@RecipeId
AND  [Order]>@Order


DELETE FROM Steps
WHERE Id=@Id

SELECT @RecipeId

