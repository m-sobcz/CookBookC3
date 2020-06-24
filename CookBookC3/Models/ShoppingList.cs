using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookC3.Models
{
    public class ShoppingList
    {
        private List<Position> positions = new List<Position>();

        public virtual void AddItem(IngredientModelUI ingredient, int quantity)
        {
            Position cartPosition = positions
                .Where(x => x.Ingredient.Name == ingredient.Name)
                .FirstOrDefault();
            
            if (cartPosition == null)
            {
                positions.Add(new Position
                {
                    Ingredient = ingredient,
                    Quantity = quantity
                });
            }
            else
            {
                cartPosition.Quantity += quantity;
            }
        }

        public virtual void RemovePosition(IngredientModelUI selectedIngredient) =>
            positions.RemoveAll(l => l.Ingredient.Name ==
                selectedIngredient.Name);

        public virtual decimal ComputeTotalValue() =>
            positions.Sum(x => x.Ingredient.CostPerUnit * x.Quantity);

        public virtual void Clear() => positions.Clear();

        public virtual IEnumerable<Position> Positions => positions;
    }

    public class Position
    {
        public int ID { get; set; }
        public IngredientModelUI Ingredient { get; set; }
        public int Quantity { get; set; }
    }
}
