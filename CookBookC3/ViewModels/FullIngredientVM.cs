using CookBookASP.Models;
using CookBookBLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookASP.ViewModels
{
    public class FullIngredientVM
    {
        public IEnumerable<IngredientWithCategoriesDTO> Ingredients { get; set; }
        public IEnumerable<CategoryVM> Categories { get; set; }
        public string SelectedCategoryName { get; set; }
        public PaginationInfo PaginationInfo { get; set; }
    }
}
