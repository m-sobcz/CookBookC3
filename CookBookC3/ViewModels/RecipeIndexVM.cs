using CookBookASP.Models;
using CookBookBLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookASP.ViewModels
{
    public class RecipeIndexVM
    {
        public IEnumerable<RecipeWithCuisinesDTO> Recipes { get; set; }
        public IEnumerable<CuisineVM> Cuisines { get; set; }
        public string SelectedCuisineName { get; set; }
        public PaginationInfo PaginationInfo { get; set; }
    }
}
