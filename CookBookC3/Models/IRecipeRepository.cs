using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookASP.Models
{
    interface IRecipeRepository
    {
        IQueryable<IngredientUIO> Recipes { get; set; }
    }
}
