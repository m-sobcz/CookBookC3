CREATE PROCEDURE [dbo].[Recipes_AddIngredient]
	@Recipes_Id  int,
	@Ingredients_Id int
AS
IF EXISTS(
SELECT *
FROM Recipes_Ingredients as ri
WHERE ri.Recipes_Id=@Recipes_Id
AND ri.Ingredients_Id=@Ingredients_Id)
UPDATE Recipes_Ingredients 
SET Recipes_Ingredients.[count]=Recipes_Ingredients.[Count]+1
WHERE Recipes_Ingredients.Recipes_Id=@Recipes_Id
AND Recipes_Ingredients.Ingredients_Id=@Ingredients_Id
ELSE
INSERT INTO Recipes_Ingredients (Recipes_Id,Ingredients_Id,[Count])
VALUES (@Recipes_Id,@Ingredients_Id,1)