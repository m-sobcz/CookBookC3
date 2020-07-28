using CookBookASP.Converters;
using CookBookASP.Extensions;
using CookBookASP.Models;
using CookBookBLL.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CookBookASP.Converters.ModelConverter;

namespace CookBookASP.Components
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
            List<CategoryUIO> categories = ingredientProcessor.GetUnusedCategories(id).DTOToUIOList(MapCategory);
            return View(categories);
        }
    }
}
