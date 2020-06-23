using DataLibrary.Models;
using System.Collections.Generic;

namespace DataLibrary.Logic
{
    public interface IIngredientProcessor
    {
        int CreateIngredient(string name, string description);
        List<IngredientModel> LoadIngredients();
    }
}