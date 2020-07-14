CREATE PROCEDURE [dbo].[Recipes_AddCuisine]
	@Recipes_Id int = 0,
	@Cuisines_Id int
AS
INSERT INTO Recipes_Cuisines(Recipes_Id,Cuisines_Id)
VALUES (@Recipes_Id, @Cuisines_Id)