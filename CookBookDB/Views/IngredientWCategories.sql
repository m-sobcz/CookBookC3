CREATE VIEW [dbo].[IngredientWCategories]
	AS 
	SELECT i.* FROM Ingredients i
	Left join Ingredients_Categories ic on i.id=ic.Ingredients_Id
	Left join Categories c on c.id=ic.Categories_Id
