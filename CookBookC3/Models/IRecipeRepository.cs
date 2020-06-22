using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookC3.Models
{
    interface IRecipeRepository
    {
        IQueryable<Ingredient> Recipes { get; set; }
    }
}
