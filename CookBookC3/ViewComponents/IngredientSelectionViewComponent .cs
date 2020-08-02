using CookBookASP.Converters;
using CookBookASP.Extensions;
using CookBookASP.Models;
using CookBookBLL.Logic;
using CookBookBLL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CookBookASP.Converters.ModelConverter;

namespace CookBookASP.Components
{
    public class IngredientSelectionViewComponent : ViewComponent
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
            List<IngredientWithCategories> loadedIngredients = ingredientProcessor.GetAllInCategory((pageId - 1) * IngredientsPerPage, IngredientsPerPage, category);
            List<CategoryUIO> Categories = categoryProcessor.GetAll().DTOToUIOList(MapCategory);
            int ingredientCount = ingredientProcessor.Count(category);
            IngredientViewModel ingredientsList = new IngredientViewModel()
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
