using CookBookASP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookASP.Models
{
    public class PurchasePosition
    {
        public int ID { get; set; }
        public IngredientVM Ingredient { get; set; }
        public decimal Quantity { get; set; }
    }
}
