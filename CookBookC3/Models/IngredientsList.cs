using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookC3.Models
{
    public class IngredientsList
    {
        public IEnumerable<IngredientWithCategories> Ingredients { get; set; }
        public IEnumerable<CategoryUIO> Categories { get; set; }
        public PaginationInfo PaginationInfo { get; set; }
    }
}
