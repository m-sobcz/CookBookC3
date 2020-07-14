CREATE PROCEDURE [dbo].[Recipes_RemoveCuisine]
	@Recipes_Id  int,
	@Cuisines_Id int
AS
DELETE FROM Recipes_Cuisines
WHERE Recipes_Cuisines.Recipes_Id=@Recipes_Id 
AND Recipes_Cuisines.Cuisines_Id=@Cuisines_Id
