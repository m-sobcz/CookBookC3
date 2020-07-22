CREATE PROCEDURE [dbo].[Ingredients_Create]
@Id int,
	@Name NVARCHAR(1000),
	@Description NVARCHAR(1000),
    @Callories int,
    @Cost DECIMAL(18, 2),
    @Unit NVARCHAR(1000)
AS
INSERT INTO Ingredients 
(Name,Description,Callories,Cost,Unit) 
VALUES (@Name, @Description,@Callories ,@Cost, @Unit)
SELECT CAST(SCOPE_IDENTITY() AS INT)