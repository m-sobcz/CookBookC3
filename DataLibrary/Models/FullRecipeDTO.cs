using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookBLL.Models
{
    public class FullRecipeDTO
    {
        public RecipeDTO Recipe { get; set; }
        public List<IngredientWithCountDTO> Ingredients { get; set; }
        public List<StepDTO> Steps { get; set; }
        public List<CuisineDTO> Cuisines { get; set; }
    }
}
