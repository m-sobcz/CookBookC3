using DataLibrary.Enums;
using DataLibrary.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLibrary.Logic
{
    public interface IIngredientProcessor
    {
        int CreateIngredient(IngredientModelDTO ingredientModel);
        List<IngredientModelDTO> LoadIngredients();
        List<IngredientModelDTO> LoadIngredients(IngredientColumn where, string value);
    }
}