select * from Categories 
LEFT JOIN Ingredients_Categories on Categories.Id=Ingredients_Categories.Categories_Id
LEFT JOIN Ingredients on Ingredients.Id=Ingredients_Categories.Ingredients_Id
where Ingredients.Id=2