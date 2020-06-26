SELECT  Categories.Name 
FROM ((Ingredients
LEFT JOIN Ingredients_Categories ON Ingredients.Id = Ingredients_Categories.Ingredients_Id)
LEFT JOIN Categories ON Categories.Id = Ingredients_Categories.Categories_Id)
WHERE Ingredients.Name='Kurczak'


SELECT  a.*
FROM    Cars a
        INNER JOIN
        (
            SELECT  CarName
            FROM    PassedTest 
            WHERE   testType IN ('A', 'B', 'C', 'D')
            GROUP   BY CarName
            HAVING  COUNT(*) = 4
        ) b ON a.CarName = b.CarName


SELECT * FROM 
(SELECT [UserID] FROM [User]) a
LEFT JOIN (SELECT [TailUser], [Weight] FROM [Edge] WHERE [HeadUser] = 5043) b
ON a.UserId = b.TailUser

select left(string,len(string)-3) 
from (
SELECT STRING_AGG(CONCAT(Title, ': ', Note, ' \n'),', ') as string
from test
) t

SELECT STRING_AGG(Title,'\n') from test 


SELECT i.Name FROM 
(SELECT Ingredients.* FROM Ingredients) i
LEFT JOIN Ingredients_Categories ON i.Id = Ingredients_Categories.Ingredients_Id
LEFT JOIN (SELECT * FROM Categories) c
ON Ingredients_Categories.Categories_Id=c.Id
Group by i.Name

SELECT i.Name, sum(c.Name) as catSum FROM
(SELECT Ingredients.* FROM Ingredients) i
LEFT JOIN Ingredients_Categories ON i.Id = Ingredients_Categories.Ingredients_Id
LEFT JOIN (SELECT * FROM Categories) c
ON Ingredients_Categories.Categories_Id=c.Id
group by i.Id, i.Name







SELECT ing.*,
STUFF((
    SELECT DISTINCT '\n' + c.Name
           FROM
            (SELECT Ingredients.* FROM Ingredients) i
            LEFT JOIN Ingredients_Categories ON i.Id = Ingredients_Categories.Ingredients_Id
            LEFT JOIN (SELECT * FROM Categories) c ON Ingredients_Categories.Categories_Id=c.Id
            WHERE i.Id = ing.id
            FOR XML PATH('')), 1, 2, '') as stuffCustom

FROM
(SELECT * FROM Ingredients) ing