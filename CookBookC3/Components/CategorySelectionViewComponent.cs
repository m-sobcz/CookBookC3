using CookBookC3.Converters;
using CookBookC3.Extensions;
using DataLibrary.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookC3.Components
{
    public class CategorySelectionViewComponent : ViewComponent
    {
        private IngredientProcessor ingredientProcessor;

        public CategorySelectionViewComponent(IngredientProcessor ingredientProcessor)
        {
            this.ingredientProcessor = ingredientProcessor;
        }
        public IViewComponentResult Invoke(int id)
        {
            var categories = ingredientProcessor.GetUnusedCategories(id).DTOToUIOList();
            return View(categories);
        }
    }
}
