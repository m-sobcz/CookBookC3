using DataLibrary.Enums;
using DataLibrary.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLibrary.Logic
{
    public interface IIngredientProcessor
    {
        int CreateIngredient(IngredientDTO ingredientModel);
        List<IngredientDTO> LoadIngredients();
        List<IngredientDTO> LoadIngredients(IngredientColumn where, string value);
    }
}