using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookASP.ViewModels
{
    public class FullRecipeVM
    {
        public RecipeVM Recipe;
        public List<IngredientWithCountVM> Ingredients { get; set; }
        public List<StepVM> Steps { get; set; }
        public List<CuisineVM> Cuisines { get; set; }
    }
}
