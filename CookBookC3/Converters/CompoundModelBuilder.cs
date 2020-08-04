using CookBookASP.Controllers;
using CookBookASP.Models;
using CookBookASP.ViewModels;
using CookBookBLL.Logic;
using CookBookBLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CookBookASP.Converters.ModelConverter;

namespace CookBookASP.Converters
{
    public class CompoundModelBuilder
    {
        private CuisineProcessor cuisineProcessor;
        private RecipeProcessor recipeProcessor;
        private IngredientProcessor ingredientProcessor;
        private CategoryProcessor categoryProcessor;

        public CompoundModelBuilder(RecipeProcessor recipeProcessor, IngredientProcessor ingredientProcessor,
            CuisineProcessor cuisineProcessor, CategoryProcessor categoryProcessor)
        {
            this.cuisineProcessor = cuisineProcessor;
            this.recipeProcessor = recipeProcessor;
            this.ingredientProcessor = ingredientProcessor;
            this.categoryProcessor = categoryProcessor;
        }
        public RecipeIndexVM GetRecipeIndexVM(int pageId, string cuisine, int RecipesPerPage)
        {
            List<RecipeWithCuisinesDTO> loadedRecipes = recipeProcessor.GetAllInCuisine((pageId - 1) * RecipesPerPage, RecipesPerPage, cuisine);
            List<CuisineVM> cuisines = cuisineProcessor.GetAll().DTOToViewModelList(MapCuisine);
            int recipeCount = recipeProcessor.Count(cuisine);
            return new RecipeIndexVM()
            {
                Recipes = loadedRecipes,
                PaginationInfo = new PaginationInfo()
                {
                    Current = pageId,
                    ItemsPerPage = RecipesPerPage,
                    ItemsCount = recipeCount
                },
                Cuisines = cuisines,
                SelectedCuisineName = cuisine
            };
        }
        public FullIngredientVM GetFullIngredientVM(int pageId, string category, int ingredientsPerPage)
        {
            List<IngredientWithCategoriesDTO> loadedIngredients = ingredientProcessor.GetAllInCategory((pageId - 1) * ingredientsPerPage, ingredientsPerPage, category);
            List<CategoryVM> Categories = categoryProcessor.GetAll().DTOToViewModelList(MapCategory);
            int ingredientCount = ingredientProcessor.Count(category);
            return new FullIngredientVM()
            {
                Ingredients = loadedIngredients,
                PaginationInfo = new PaginationInfo()
                {
                    Current = pageId,
                    ItemsPerPage = ingredientsPerPage,
                    ItemsCount = ingredientCount
                },
                Categories = Categories,
                SelectedCategoryName = category
            };
        }

    }
}
