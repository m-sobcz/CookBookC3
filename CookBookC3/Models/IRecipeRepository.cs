using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookC3.Models
{
    interface IRecipeRepository
    {
        IQueryable<IngredientModelUI> Recipes { get; set; }
    }
}
