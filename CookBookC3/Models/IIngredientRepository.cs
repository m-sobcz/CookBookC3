using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookC3.Models
{
    public interface IIngredientRepository
    {
        IQueryable<Ingredient> Ingredients { get; }
    }
}
