CREATE PROCEDURE [dbo].[Ingredients_AddCategory]
	@Ingredients_Id int = 0,
	@Categories_Id int
AS
INSERT INTO Ingredients_Categories(Ingredients_Id,Categories_Id)
VALUES (@Ingredients_Id, @Categories_Id)