using CookBookBLL.DataAccess;
using CookBookBLL.Enums;
using CookBookBLL.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace CookBookBLL.Logic
{
    public class IngredientProcessor : Processor
    {
        private SqlDataAccess sqlDataAccess;

        public IngredientProcessor(SqlDataAccess sqlDataAccess)
        {
            this.sqlDataAccess = sqlDataAccess;
            defaultStoredProceduresPrefix = "Ingredients";
        }
        public int Create(IngredientDTO ingredientModel)
        {
            return sqlDataAccess.Save(GetDefaultStoredProcedureName(), ingredientModel);
        }
        public int Update(IngredientDTO ingredientModel)
        {
            return sqlDataAccess.Save(GetDefaultStoredProcedureName(), ingredientModel);
        }
        public IngredientDTO Get(int id)
        {
            var parameter = new
            {
                Id = id
            };
            return sqlDataAccess.Load<IngredientDTO>(GetDefaultStoredProcedureName(), parameter).FirstOrDefault();
        }
        public List<IngredientWithCategoriesDTO> GetAllInCategory(int startIndex, int numberOfRows, string categoryName=null)
        {
            var parameters = new
            {
                StartIndex = startIndex,
                NumberOfRows = numberOfRows,
                CategoryName= categoryName
            };
            return sqlDataAccess.Load<IngredientWithCategoriesDTO, string, IngredientWithCategoriesDTO>
                (
                GetDefaultStoredProcedureName(),
                (ingredient, categories) => { ingredient.Categories = categories; return ingredient; },
                parameters,
                splitOn: "CategoryList"
                );
        }

        public List<CategoryDTO> GetCategories(int ingredientId)
        {
            var parameter = new
            {
                Id = ingredientId
            };
            
            return sqlDataAccess.Load<CategoryDTO>(GetDefaultStoredProcedureName(),parameter);
        }
        public int Count(string categoryName) 
        {
            var parameters = new
            {
                CategoryName = categoryName
            };
            return sqlDataAccess.Load<int>(GetDefaultStoredProcedureName(), parameters).FirstOrDefault();
        }
        public int RemoveCategory(int ingredientId, int categoryId)
        {
            var parameter = new
            {
                Ingredients_Id= ingredientId,
                Categories_Id=categoryId
            };
            return sqlDataAccess.Delete(GetDefaultStoredProcedureName(),parameter);
        }
        public int Delete(int id)
        {
            var parameter = new
            {
                Id = id
            };
            //sqlDataAccess.DeleteData("IngredientsCategories_DeleteByIngredients", parameter);
            return sqlDataAccess.Delete(GetDefaultStoredProcedureName(), parameter);
        }
        public int AddCategory(int ingredientId, int categoryId)
        {
            var parameter = new
            {
                Ingredients_Id = ingredientId,
                Categories_Id = categoryId
            };
            return sqlDataAccess.Save(GetDefaultStoredProcedureName(), parameter);
        }
        public List<CategoryDTO> GetUnusedCategories(int ingredientId)
        {
            var parameter = new
            {
                Id = ingredientId
            };
            return sqlDataAccess.Load<CategoryDTO>(GetDefaultStoredProcedureName(), parameter);
        }
    }
}
