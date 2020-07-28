CREATE PROCEDURE [dbo].[Steps_Get]
	@Id int
AS
SELECT s.* 
FROM Steps s
JOIN Recipes r on r.Id=s.Recipe_Id
WHERE r.Id=@Id