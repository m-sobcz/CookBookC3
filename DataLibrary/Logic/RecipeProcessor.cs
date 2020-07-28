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
            return sqlDataAccess.SaveData(GetDefaultStoredProcedureName(), recipeModel);
        }
        public int Update(RecipeDTO recipeModel)
        {
            return sqlDataAccess.SaveData(GetDefaultStoredProcedureName(), recipeModel);
        }
        public RecipeDTO Get(int id)
        {
            var parameter = new
            {
                Id = id
            };
            return sqlDataAccess.LoadData<RecipeDTO>(GetDefaultStoredProcedureName(), parameter).FirstOrDefault();
        }
        public List<RecipeWithCuisines> GetAllInCuisine(int startIndex, int numberOfRows, string cuisineName = null)
        {
            var parameters = new
            {
                StartIndex = startIndex,
                NumberOfRows = numberOfRows,
                CuisineName = cuisineName
            };
            return sqlDataAccess.LoadData<RecipeWithCuisines, string, RecipeWithCuisines>
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

            return sqlDataAccess.LoadData<CuisineDTO>(GetDefaultStoredProcedureName(), parameter);
        }
        public int Count(string cuisineName = null)
        {
            var parameters = new
            {
                CuisineName = cuisineName
            };
            return sqlDataAccess.LoadData<int>(GetDefaultStoredProcedureName(), parameters).FirstOrDefault();
        }
        public int RemoveCuisine(int recipeID, int cuisineId)
        {
            var parameter = new
            {
                Recipes_Id = recipeID,
                Cuisines_Id = cuisineId
            };
            return sqlDataAccess.DeleteData(GetDefaultStoredProcedureName(), parameter);
        }
        public int Delete(int id)
        {
            var parameter = new
            {
                Id = id
            };
            sqlDataAccess.DeleteData("RecipesCuisines_DeleteByRecipes", parameter);
            return sqlDataAccess.DeleteData(GetDefaultStoredProcedureName(), parameter);
        }
        public int AddCuisine(int recipeId, int cuisineId)
        {
            var parameter = new
            {
                Recipes_Id = recipeId,
                Cuisines_Id = cuisineId
            };
            return sqlDataAccess.SaveData(GetDefaultStoredProcedureName(), parameter);
        }
        public List<CuisineDTO> GetUnusedCuisines(int recipeID)
        {
            var parameter = new
            {
                Id = recipeID
            };
            return sqlDataAccess.LoadData<CuisineDTO>(GetDefaultStoredProcedureName(), parameter);
        }
        
    }
}
