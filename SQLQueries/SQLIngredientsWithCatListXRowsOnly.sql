SELECT
i1.*,
STUFF((
    SELECT DISTINCT '\n' + c.Name
    FROM
            (
                SELECT Ingredients.* FROM Ingredients) i2
                LEFT JOIN Ingredients_Categories ON i2.Id = Ingredients_Categories.Ingredients_Id
                LEFT JOIN (SELECT * FROM Categories) c ON Ingredients_Categories.Categories_Id=c.Id
                WHERE i1.Id = i2.Id 
                FOR XML PATH('')), 1, 2, ''
            ) as CategoryList
FROM Ingredients i1  
ORDER by i1.Id
OFFSET 0 ROWS FETCH NEXT 2 ROWS ONLY