using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookASP.Models
{
    public class FullRecipeUIO
    {
        public RecipeUIO Recipe;
        public List<IngredientWithCountUIO> Ingredients { get; set; }
        public List<StepUIO> Steps { get; set; }
        public List<CuisineUIO> Cuisines { get; set; }
    }
}
