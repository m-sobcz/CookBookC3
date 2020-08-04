using CookBookASP.Converters;
using CookBookASP.Extensions;
using CookBookASP.Models;
using CookBookASP.ViewModels;
using CookBookBLL.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CookBookASP.Converters.ModelConverter;

namespace CookBookASP.ViewComponents
{
    public class CategorySelectionViewComponent : ViewComponentBase<CategorySelectionViewComponent>
    {
        private IngredientProcessor ingredientProcessor;

        public CategorySelectionViewComponent(IngredientProcessor ingredientProcessor)
        {
            this.ingredientProcessor = ingredientProcessor;
        }
        public IViewComponentResult Invoke(int id)
        {
            List<CategoryVM> categories = ingredientProcessor.GetUnusedCategories(id).DTOToViewModelList(MapCategory);
            return View(categories);
        }
    }
}
