using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookASP.ViewModels
{
    public class IngredientsPageVM
    {
        public List<IngredientWithCountVM> Ingredients { get; set; }
        public int PageId { get; set; }
        public int RecipeId { get; set; }
        public string Category { get; set; }
    }
}
