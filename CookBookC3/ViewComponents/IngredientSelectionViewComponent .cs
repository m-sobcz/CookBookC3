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
        private CompoundModelBuilder compoundModelBuilder;

        public int IngredientsPerPage { get; set; } = 6;

        public IngredientSelectionViewComponent(CompoundModelBuilder compoundModelBuilder)
        {
            this.compoundModelBuilder = compoundModelBuilder;
        }
        public IViewComponentResult Invoke(int recipeId, int pageId = 1, string category = null) 
        {
            ViewBag.recipeId = recipeId;
            FullIngredientVM ingredientsList = compoundModelBuilder.GetFullIngredientVM(pageId, category, IngredientsPerPage);
            return View(ingredientsList);
        }
    }
}
