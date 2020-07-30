using CookBookASP.Models;
using CookBookBLL.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookASP.Converters
{
    public static class ModelConverter
    {
        public static List<TUIO> DTOToUIOList<TDTO, TUIO>(this IEnumerable<TDTO> data, Func<TDTO, TUIO> convert)
        {
            List<TUIO> tuioList = new List<TUIO>();
            foreach (var row in data)
            {
                tuioList.Add(row.DTOToUIO(convert));
            }
            return tuioList;
        }
        public static TUIO DTOToUIO<TDTO, TUIO>(this TDTO dto, Func<TDTO,TUIO> convert) 
        {
            return convert(dto);
        }
        public static CategoryUIO MapCategory(CategoryDTO dto)
        {
            return new CategoryUIO()
            {
                Description = dto.Description,
                Id = dto.Id,
                Name = dto.Name
            };
        }
        public static IngredientUIO MapIngredient(IngredientDTO dto)
        {
            return new IngredientUIO()
            {
                Description = dto.Description,
                Id = dto.Id,
                Name = dto.Name,
                Callories = dto.Callories,
                Cost = dto.Cost,
                Unit = dto.Unit
            };
        }
        public static IngredientWithCountUIO MapIngredientWithCount(IngredientWithCountDTO dto)
        {
            return new IngredientWithCountUIO()
            {
                Description = dto.Description,
                Id = dto.Id,
                Name = dto.Name,
                Callories = dto.Callories,
                Cost = dto.Cost,
                Unit = dto.Unit,
                Count=dto.Count
            };
        }
        public static CuisineUIO MapCuisine(CuisineDTO dto)
        {
            return new CuisineUIO()
            {
                Description = dto.Description,
                Id = dto.Id,
                Name = dto.Name,
            };
        }
        public static RecipeUIO MapRecipe(RecipeDTO dto)
        {
            return new RecipeUIO()
            {
                Description = dto.Description,
                Id = dto.Id,
                Name = dto.Name,
                Time = dto.Time,
                Portions=dto.Portions
            };
        }
        public static StepUIO MapStep(StepDTO dto)
        {
            return new StepUIO()
            {
                Id=dto.Id,
                Order=dto.Order,
                Description=dto.Description
            };
        }
    }
}
