using CookBookC3.Extensions;
using DataLibrary.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookC3.Components
{
    public class CategorySelectionMenu : ViewComponent
    {
        private IIngredientProcessor ingredientProcessor;

        public CategorySelectionMenu(IIngredientProcessor ingredientProcessor)
        {
            this.ingredientProcessor = ingredientProcessor;
        }
        public IViewComponentResult Invoke()
        {
            var ingredients = ingredientProcessor.LoadIngredients();
            var categories = ingredients.Select(x => x.Name)//CATEGORY!
                .Where(x => x != null)
                .ReplaceStrings(" ","")
                .Distinct();
            return View(categories);
        }
    }
}
