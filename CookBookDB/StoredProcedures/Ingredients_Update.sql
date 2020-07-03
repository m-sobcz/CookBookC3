CREATE PROCEDURE [dbo].[Ingredients_Update]
    @Id int,
	@Name NVARCHAR(1000),
	@Description NVARCHAR(1000),
    @Callories int,
    @Cost DECIMAL(18, 2),
    @Unit NVARCHAR(1000)
AS
UPDATE Ingredients 
SET Name=@Name, Description=@Description, Callories=@Callories, Cost=@Cost 
WHERE Id=@Id