using System;
using System.Collections.Generic;
using System.Text;

namespace CookBookBLL.Models
{
    public class IngredientWithCountDTO : IngredientDTO
    {
        public decimal Count { get; set; }
    }
}
