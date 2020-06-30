using DataLibrary.Enums;
using DataLibrary.Models;
using System.Collections.Generic;

namespace DataLibrary.Logic
{
    public interface IIngredientProcessor
    {
        int Create(IngredientDTO ingredientModel);
        List<CategoryDTO> LoadCategories();
        List<IngredientWithCategories> LoadRowsWithCategories(int startIndex, int numberOfRows, string categoryName = null);
        public int IngredientCount();
        IngredientDTO Load(int id);
    }
}