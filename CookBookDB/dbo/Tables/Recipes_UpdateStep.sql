CREATE PROCEDURE [dbo].[Recipes_UpdateStep]
	@Description NVarchar(1000),
	@Id int,
	@Order int,
	@Recipe_Id int
AS
UPDATE Steps 
SET [Description]=@Description, [Order]=@Order
WHERE Id=@Id
SELECT CAST(SCOPE_IDENTITY() AS INT)