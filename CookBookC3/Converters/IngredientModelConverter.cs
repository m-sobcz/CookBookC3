using CookBookC3.Models;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookC3.Converters
{
    public static class IngredientModelConverter
    {
        public static List<IngredientUIO> DTOToUIOList(this IEnumerable<IngredientDTO> data)
        {
            List<IngredientUIO> Ingredients = new List<IngredientUIO>();
            foreach (var row in data)
            {
                Ingredients.Add(row.DTOToUIO());
            }
            return Ingredients;
        }
        public static IngredientUIO DTOToUIO(this IngredientDTO dto)
        {
            return new IngredientUIO()
            {
                Id=dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Unit = dto.Unit,
                Callories = dto.Callories,
                Cost = dto.Cost
            };
        }
    }
}
