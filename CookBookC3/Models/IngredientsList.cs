using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookC3.Models
{
    public class IngredientsList
    {
        public IEnumerable<Ingredient> Ingredients { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
