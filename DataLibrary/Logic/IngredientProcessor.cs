using DataLibrary.DataAccess;
using DataLibrary.Enums;
using DataLibrary.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace DataLibrary.Logic
{
    public class IngredientProcessor
    {
        private SqlDataAccess sqlDataAccess;

        public IngredientProcessor(SqlDataAccess sqlDataAccess)
        {
            this.sqlDataAccess = sqlDataAccess;
        }
        public int Create(IngredientDTO ingredientModel)
        {
            string sql = $@"insert into dbo.Ingredients (Name,Description,Callories,Cost) values (@Name, @Description,@Callories ,@Cost)";
            return sqlDataAccess.SaveData(sql, ingredientModel);
        }
        public IngredientDTO Load(int id)
        {
            var parameter = new
            {
                Id = id
            };
            string sql = $@"select * from dbo.Ingredients where Ingredients.Id=@Id";//'{value}'
            return sqlDataAccess.LoadData<IngredientDTO>(sql, parameter).FirstOrDefault();
        }
        public List<IngredientWithCategories> LoadRowsWithCategories(int startIndex, int numberOfRows, string categoryName=null)
        {
            var parameters = new
            {
                StartIndex = startIndex,
                NumberOfRows = numberOfRows,
                CategoryName= categoryName
            };
            string filter= (categoryName!=null) ?@" WHERE c2.Name=@CategoryName " : " ";
            string sql = $@"
SELECT distinct
i1.*,
STUFF((
    SELECT DISTINCT ', ' + c.Name
    FROM
            (
                SELECT Ingredients.* FROM Ingredients) i2
                LEFT JOIN Ingredients_Categories ON i2.Id = Ingredients_Categories.Ingredients_Id
                LEFT JOIN (SELECT * FROM Categories) c ON Ingredients_Categories.Categories_Id=c.Id
                WHERE i1.Id = i2.Id 
                FOR XML PATH('')), 1, 2, ''
            ) as CategoryList
FROM Ingredients i1 
LEFT JOIN Ingredients_Categories ON i1.Id = Ingredients_Categories.Ingredients_Id
LEFT JOIN (SELECT * FROM Categories) c2 ON Ingredients_Categories.Categories_Id=c2.Id"+
filter+
@$" ORDER by i1.Id
OFFSET @StartIndex ROWS FETCH NEXT @NumberOfRows ROWS ONLY";
            return sqlDataAccess.LoadData<IngredientWithCategories, string, IngredientWithCategories>
                (
                sql,
                (ingredient, categories) => { ingredient.Categories = categories; return ingredient; },
                parameters
                );
        }

        public List<CategoryDTO> LoadCategories(int ingredientId)
        {
            var parameter = new
            {
                Id = ingredientId
            };
            string sql = $@"select Categories.* from Categories 
LEFT JOIN Ingredients_Categories on Categories.Id=Ingredients_Categories.Categories_Id
LEFT JOIN Ingredients on Ingredients.Id=Ingredients_Categories.Ingredients_Id
where Ingredients.Id=@Id";
            return sqlDataAccess.LoadData<CategoryDTO>(sql,parameter);
        }
        public int IngredientCount() 
        {
            string sql = $@"select count(id) from Ingredients"; //Name,Description,Callories,Category,CostPerUnit
            return sqlDataAccess.LoadData<int>(sql).FirstOrDefault();
        }
        public int RemoveCategory(int ingredientId, int categoryId)
        {
            var parameter = new
            {
                Ingredients_Id= ingredientId,
                Categories_Id=categoryId
            };
            string sql = $@"DELETE FROM Ingredients_Categories
WHERE Ingredients_Categories.Ingredients_Id=@Ingredients_Id and Ingredients_Categories.Categories_Id=@Categories_Id";
            return sqlDataAccess.DeleteData(sql,parameter);
        }
        public int AddCategory(int ingredientId, int categoryId)
        {
            var parameter = new
            {
                Ingredients_Id = ingredientId,
                Categories_Id = categoryId
            };
            string sql = $@"INSERT INTO Ingredients_Categories(Ingredients_Id,Categories_Id)
VALUES (@Ingredients_Id, @Categories_Id);";
            return sqlDataAccess.DeleteData(sql, parameter);
        }
        public List<CategoryDTO> LoadUnusedCategories(int ingredientId)
        {
            var parameter = new
            {
                Id = ingredientId
            };
            string sql = $@"select Categories.* from Categories 
LEFT JOIN Ingredients_Categories on Categories.Id=Ingredients_Categories.Categories_Id
except
select Categories.* from Categories 
LEFT JOIN Ingredients_Categories on Categories.Id=Ingredients_Categories.Categories_Id
where Ingredients_Categories.Ingredients_Id=@Id";
            return sqlDataAccess.LoadData<CategoryDTO>(sql, parameter);
        }
    }
}
