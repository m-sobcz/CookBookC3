using DataLibrary.Enums;
using DataLibrary.Models;
using System.Collections.Generic;

namespace DataLibrary.Logic
{
    public interface IIngredientProcessor
    {
        int CreateIngredient(IngredientDTO ingredientModel);
        List<CategoryDTO> LoadCategories();
        List<IngredientDTO> LoadIngredients();
        List<IngredientDTO> LoadIngredients(IngredientColumn column, string value);
        List<IngredientWithCategories> LoadIngredientsWithCategories(int startIndex, int numberOfRows, string categoryName = null);
        public int IngredientCount();
    }
}