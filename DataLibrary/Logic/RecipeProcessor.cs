using CookBookBLL.DataAccess;
using CookBookBLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CookBookBLL.Logic
{
    public class RecipeProcessor : Processor
    {
        private SqlDataAccess sqlDataAccess;

        public RecipeProcessor(SqlDataAccess sqlDataAccess)
        {
            this.sqlDataAccess = sqlDataAccess;
            defaultStoredProceduresPrefix = "Recipes";
        }
        public int Create(RecipeDTO recipeModel)
        {
            return sqlDataAccess.Save(GetDefaultStoredProcedureName(), recipeModel);
        }
        public int Update(RecipeDTO recipeModel)
        {
            return sqlDataAccess.Save(GetDefaultStoredProcedureName(), recipeModel);
        }
        public RecipeDTO Get(int id)
        {
            var parameter = new
            {
                Id = id
            };
            return sqlDataAccess.Load<RecipeDTO>(GetDefaultStoredProcedureName(), parameter).FirstOrDefault();
        }
        public List<RecipeWithCuisines> GetAllInCuisine(int startIndex, int numberOfRows, string cuisineName = null)
        {
            var parameters = new
            {
                StartIndex = startIndex,
                NumberOfRows = numberOfRows,
                CuisineName = cuisineName
            };
            return sqlDataAccess.Load<RecipeWithCuisines, string, RecipeWithCuisines>
                (
                GetDefaultStoredProcedureName(),
                (recipe, cuisines) => { recipe.Cuisines = cuisines; return recipe; },
                parameters,
                splitOn: "CuisineList"
                );
        }

        public List<CuisineDTO> GetCuisines(int recipeID)
        {
            var parameter = new
            {
                Id = recipeID
            };

            return sqlDataAccess.Load<CuisineDTO>(GetDefaultStoredProcedureName(), parameter);
        }

        public int Count(string cuisine)
        {
            var parameters = new
            {
                CuisineName = cuisine
            };
            return sqlDataAccess.Load<int>(GetDefaultStoredProcedureName(), parameters).FirstOrDefault();
        }
        public int RemoveCuisine(int recipeID, int cuisineId)
        {
            var parameter = new
            {
                Recipes_Id = recipeID,
                Cuisines_Id = cuisineId
            };
            return sqlDataAccess.Delete(GetDefaultStoredProcedureName(), parameter);
        }
        public int Delete(int id)
        {
            var parameter = new
            {
                Id = id
            };
            return sqlDataAccess.Delete(GetDefaultStoredProcedureName(), parameter);
        }
        public int AddCuisine(int recipeId, int cuisineId)
        {
            var parameter = new
            {
                Recipes_Id = recipeId,
                Cuisines_Id = cuisineId
            };
            return sqlDataAccess.Save(GetDefaultStoredProcedureName(), parameter);
        }
        public List<CuisineDTO> GetUnusedCuisines(int recipeID)
        {
            var parameter = new
            {
                Id = recipeID
            };
            return sqlDataAccess.Load<CuisineDTO>(GetDefaultStoredProcedureName(), parameter);
        }
        public List<IngredientDTO> GetIngredients(int recipeId)
        {
            var parameter = new
            {
                Id = recipeId
            };

            return sqlDataAccess.Load<IngredientDTO>(GetDefaultStoredProcedureName(), parameter);
        }
        public List<IngredientWithCountDTO> GetIngredientsWithCount(int recipeId)
        {
            var parameters = new
            {
                Id = recipeId
            };
            return sqlDataAccess.Load<IngredientWithCountDTO, int, IngredientWithCountDTO>
                (
                GetDefaultStoredProcedureName(),
                (ingredient, count) => { ingredient.Count = count; return ingredient; },
                parameters,
                splitOn: "Count"
                );
        }
        public int AddIngredient(int recipeId, int ingredientId)
        {
            //Add or increment count
            var parameter = new
            {
                Recipes_Id = recipeId,
                Ingredients_Id = ingredientId
            };
            return sqlDataAccess.Save(GetDefaultStoredProcedureName(), parameter);
        }
        public int RemoveIngredient(int recipeID, int ingredientId)
        {
            var parameter = new
            {
                Recipes_Id = recipeID,
                Ingredients_Id = ingredientId
            };
            return sqlDataAccess.Delete(GetDefaultStoredProcedureName(), parameter);
        }
        public int EditIngredientCount(int recipeID, int ingredientId, int count)
        {
            var parameter = new
            {
                Recipes_Id = recipeID,
                Ingredients_Id = ingredientId,
                Count=count
            };
            return sqlDataAccess.Save(GetDefaultStoredProcedureName(), parameter);
        }
    }
}
