CREATE PROCEDURE [dbo].[Cuisines_Get]
	@Id int
AS
SELECT * 
FROM Cuisines
WHERE Cuisines.Id=@Id

