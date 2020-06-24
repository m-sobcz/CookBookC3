using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookC3.Models
{
    public class PurchasePosition
    {
        public int ID { get; set; }
        public IngredientModelUI Ingredient { get; set; }
        public int Quantity { get; set; }
    }
}
