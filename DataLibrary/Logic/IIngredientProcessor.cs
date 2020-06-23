using DataLibrary.Models;
using System.Collections.Generic;

namespace DataLibrary.Logic
{
    public interface IIngredientProcessor
    {
        int CreateIngredient(IngredientModelDTO ingredientModel);
        List<IngredientModelDTO> LoadIngredients();
    }
}