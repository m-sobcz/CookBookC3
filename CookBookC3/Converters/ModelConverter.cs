using CookBookASP.Models;
using CookBookASP.ViewModels;
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
        public static List<TViewModel> DTOToViewModelList<TDTO, TViewModel>(this IEnumerable<TDTO> data, Func<TDTO, TViewModel> convert)
        {
            List<TViewModel> tVMList = new List<TViewModel>();
            foreach (var row in data)
            {
                tVMList.Add(row.DTOToViewModel(convert));
            }
            return tVMList;
        }
        public static TViewModel DTOToViewModel<TDTO, TViewModel>(this TDTO dto, Func<TDTO,TViewModel> convert) 
        {
            return convert(dto);
        }
        public static CategoryVM MapCategory(CategoryDTO dto)
        {
            return new CategoryVM()
            {
                Description = dto.Description,
                Id = dto.Id,
                Name = dto.Name
            };
        }
        public static IngredientVM MapIngredient(IngredientDTO dto)
        {
            return new IngredientVM()
            {
                Description = dto.Description,
                Id = dto.Id,
                Name = dto.Name,
                Callories = dto.Callories,
                Cost = dto.Cost,
                Unit = dto.Unit
            };
        }
        public static IngredientWithCountVM MapIngredientWithCount(IngredientWithCountDTO dto)
        {
            return new IngredientWithCountVM()
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
        public static CuisineVM MapCuisine(CuisineDTO dto)
        {
            return new CuisineVM()
            {
                Description = dto.Description,
                Id = dto.Id,
                Name = dto.Name,
            };
        }
        public static RecipeVM MapRecipe(RecipeDTO dto)
        {
            return new RecipeVM()
            {
                Description = dto.Description,
                Id = dto.Id,
                Name = dto.Name,
                Time = dto.Time,
                Portions=dto.Portions
            };
        }

        public static StepVM MapStep(StepDTO dto)
        {
            return new StepVM()
            {
                Id=dto.Id,
                Order=dto.Order,
                Description=dto.Description
            };
        }
        public static FullRecipeVM MapFullRecipe(FullRecipeDTO dto)
        {
            return new FullRecipeVM()
            {
                Recipe=dto.Recipe.DTOToViewModel(MapRecipe),
                Ingredients = dto.Ingredients.DTOToViewModelList(MapIngredientWithCount),
                Cuisines = dto.Cuisines.DTOToViewModelList(MapCuisine),
                Steps = dto.Steps.DTOToViewModelList(MapStep)

            };
        }
    }
}
