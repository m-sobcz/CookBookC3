using DataLibrary.DataAccess;
using DataLibrary.Enums;
using DataLibrary.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
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
        public int CreateIngredient(IngredientDTO ingredientModel)
        {
            string sql = $@"insert into dbo.Ingredients (Name,Description,Callories,Cost) values (@Name, @Description,@Callories ,@Cost)";
            return sqlDataAccess.SaveData(sql, ingredientModel);
        }
        public List<IngredientDTO> LoadIngredients()
        {
            string sql = $@"select * from dbo.Ingredients"; //Name,Description,Callories,Category,CostPerUnit
            return sqlDataAccess.LoadData<IngredientDTO>(sql);
        }
        public List<IngredientDTO> LoadIngredients(IngredientColumn column, string value)
        {
            //parameter injection
            var parameter = new
            {
                Value = value
            };
            string sql = $@"select * from dbo.Ingredients where '{column}'=@Value";//'{value}'
            return sqlDataAccess.LoadData<IngredientDTO>(sql, parameter);
        }
        public List<IngredientWithCategories> LoadIngredientsWithCategories(int startIndex, int endIndex)
        {
            var parameters = new
            {
                StartIndex = startIndex,
                EndIndex = endIndex
            };
            string sql = $@"
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
OFFSET @StartIndex ROWS FETCH NEXT @EndIndex ROWS ONLY
";
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
    }
}
