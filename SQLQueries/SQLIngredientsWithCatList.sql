SELECT i1.*,
STUFF((
    SELECT DISTINCT '\n' + c.Name
    FROM
            (
                SELECT Ingredients.* FROM Ingredients) i2
                LEFT JOIN Ingredients_Categories ON i2.Id = Ingredients_Categories.Ingredients_Id
                LEFT JOIN (SELECT * FROM Categories) c ON Ingredients_Categories.Categories_Id=c.Id
                WHERE i1.Id = i2.id
                FOR XML PATH('')), 1, 2, ''
            ) as CategoryList
FROM
(SELECT * FROM Ingredients) i1