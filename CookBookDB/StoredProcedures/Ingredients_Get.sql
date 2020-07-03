CREATE PROCEDURE [dbo].[Ingredients_Get]
    @Id int
AS
SELECT * 
FROM dbo.Ingredients 
WHERE Ingredients.Id=@Id