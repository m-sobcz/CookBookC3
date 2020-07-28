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
    public class CuisineSelectionViewComponent : ViewComponent
    {
        private RecipeProcessor recipeProcessor;

        public CuisineSelectionViewComponent(RecipeProcessor recipeProcessor)
        {
            this.recipeProcessor = recipeProcessor;
        }
        public IViewComponentResult Invoke(int id)
        {
            List<CuisineUIO> cuisines = recipeProcessor.GetUnusedCuisines(id).DTOToUIOList(MapCuisine);
            return View(cuisines);
        }
    }
}
