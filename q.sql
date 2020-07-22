SELECT distinct i.Id
FROM Ingredients i
inner JOIN Ingredients_Categories ic ON i.Id = ic.Ingredients_Id
inner JOIN (SELECT * FROM Categories) c ON ic.Categories_Id=c.Id
