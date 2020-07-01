using CookBookC3.Models;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookC3.Converters
{
    public static class CategoryModelConverter
    {
        public static List<CategoryUIO> DTOToUIOList(this IEnumerable<CategoryDTO> data)
        {
            List<CategoryUIO> Ingredients = new List<CategoryUIO>();
            foreach (var row in data)
            {
                Ingredients.Add(row.DTOToUIO());
            }
            return Ingredients;
        }
        public static CategoryUIO DTOToUIO(this CategoryDTO dto)
        {
            return new CategoryUIO()
            {
                Id=dto.Id,
                Name = dto.Name,
                Description = dto.Description,
            };
        }
    }
}
