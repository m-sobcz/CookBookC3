CREATE VIEW [dbo].[IngredientWCategories]
	AS 
	SELECT i.* FROM Ingredients i
	Left join Ingredients_Categories ic on i.Id=ic.Ingredients_Id
	Left join Categories c on c.Id=ic.Categories_Id
