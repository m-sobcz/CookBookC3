using CookBookASP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookASP.Models
{
    public class Purchase
    {
        public List<PurchasePosition> Positions = new List<PurchasePosition>();

        public virtual void AddItem(IngredientVM ingredient, decimal quantity)
        {
            PurchasePosition ingredientPosition = Positions
                .Where(x => x.Ingredient.Name == ingredient.Name)
                .FirstOrDefault();
            
            if (ingredientPosition == null)
            {
                Positions.Add(new PurchasePosition
                {
                    Ingredient = ingredient,
                    Quantity = quantity
                });
            }
            else
            {
                ingredientPosition.Quantity += quantity;
            }
        }

        public virtual void RemovePosition(IngredientVM selectedIngredient) =>
            Positions.RemoveAll(l => l.Ingredient.Name ==
                selectedIngredient.Name);

        public virtual decimal ComputeTotalValue() =>
            Positions.Sum(x => x.Ingredient.Cost * x.Quantity);

        public virtual void Clear() => Positions.Clear();

    }


}
