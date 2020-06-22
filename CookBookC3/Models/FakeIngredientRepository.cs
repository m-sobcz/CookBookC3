using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookC3.Models
{
    public class FakeIngredientRepository : IIngredientRepository
    {
        public IQueryable<Ingredient> Ingredients => new List<Ingredient>
        {
            new Ingredient(){ Name="Mąka", Description="Zwykła mąka pszenna, typ 450", Units="g"},
            new Ingredient(){ Name="Mleko", Description="Krowie", Units="ml"},
            new Ingredient(){ Name="Jajko", Description="Kurze", Units="szt"},
            new Ingredient(){ Name="Woda", Description="Z kranu", Units="ml"}
        }.AsQueryable<Ingredient>();
    }
}
