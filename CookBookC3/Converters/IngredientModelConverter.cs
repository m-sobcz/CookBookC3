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
        public static List<IngredientModelUI> DTOToUIList(this IEnumerable<IngredientModelDTO> data)
        {
            List<IngredientModelUI> Ingredients = new List<IngredientModelUI>();
            foreach (var row in data)
            {
                Ingredients.Add(row.DTOToUI());
            }
            return Ingredients;
        }
        public static IngredientModelUI DTOToUI(this IngredientModelDTO dto)
        {
            return new IngredientModelUI()
            {
                Name = dto.Name,
                Description = dto.Description,
                Unit = dto.Unit,
                Callories = dto.Callories,
                CostPerUnit = dto.Cost
            };
        }
    }
}
