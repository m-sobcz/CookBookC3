using CookBookASP.Converters;
using CookBookASP.Extensions;
using CookBookASP.Models;
using CookBookASP.ViewModels;
using CookBookBLL.Logic;
using CookBookBLL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CookBookASP.Converters.ModelConverter;

namespace CookBookASP.ViewComponents
{
    public class IngredientSelectionViewComponent : ViewComponentBase<IngredientSelectionViewComponent>
    {
        private IngredientProcessor ingredientProcessor;
        private CategoryProcessor categoryProcessor;
        public int IngredientsPerPage { get; set; } = 6;

        public IngredientSelectionViewComponent(IngredientProcessor ingredientProcessor, CategoryProcessor categoryProcessor)
        {
            this.ingredientProcessor = ingredientProcessor;
            this.categoryProcessor = categoryProcessor;
        }
        public IViewComponentResult Invoke(int recipeId, int pageId = 1, string category = null) //DRY!
        {
            ViewBag.recipeId = recipeId;
            List<IngredientWithCategoriesDTO> loadedIngredients = ingredientProcessor.GetAllInCategory((pageId - 1) * IngredientsPerPage, IngredientsPerPage, category);
            List<CategoryVM> Categories = categoryProcessor.GetAll().DTOToViewModelList(MapCategory);
            int ingredientCount = ingredientProcessor.Count(category);
            FullIngredientVM ingredientsList = new FullIngredientVM()
            {
                Ingredients = loadedIngredients,
                PaginationInfo = new PaginationInfo()
                {
                    Current = pageId,
                    ItemsPerPage = IngredientsPerPage,
                    ItemsCount = ingredientCount
                },
                Categories = Categories,
                SelectedCategoryName = category
            };
            return View(ingredientsList);
        }
    }
}
