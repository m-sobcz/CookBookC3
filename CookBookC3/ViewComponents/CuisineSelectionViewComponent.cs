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
    public class CuisineSelectionViewComponent : ViewComponentBase<CuisineSelectionViewComponent>
    {
        private RecipeProcessor recipeProcessor;

        public CuisineSelectionViewComponent(RecipeProcessor recipeProcessor)
        {
            this.recipeProcessor = recipeProcessor;
        }
        public IViewComponentResult Invoke(int id)
        {
            List<CuisineVM> cuisines = recipeProcessor.GetUnusedCuisines(id).DTOToViewModelList(MapCuisine);
            return View(cuisines);
        }
    }
}
