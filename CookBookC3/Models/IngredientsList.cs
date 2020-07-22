using CookBookBLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookASP.Models
{
    public class IngredientsList
    {
        public IEnumerable<IngredientWithCategories> Ingredients { get; set; }
        public IEnumerable<CategoryUIO> Categories { get; set; }
        public string SelectedCategoryName { get; set; }
        public PaginationInfo PaginationInfo { get; set; }
    }
}
