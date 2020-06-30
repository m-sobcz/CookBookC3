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
    public class IngredientProcessor : IIngredientProcessor
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
        public List<CategoryDTO> LoadCategories()
        {
            string sql = $@"select * from dbo.Categories"; //Name,Description,Callories,Category,CostPerUnit
            return sqlDataAccess.LoadData<CategoryDTO>(sql);
        }
        public int IngredientCount() 
        {
            string sql = $@"select count(id) from Ingredients"; //Name,Description,Callories,Category,CostPerUnit
            return sqlDataAccess.LoadData<int>(sql).FirstOrDefault();
        }
    }
}
