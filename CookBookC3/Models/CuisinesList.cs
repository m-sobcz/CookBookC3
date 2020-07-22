using CookBookBLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookASP.Models
{
    public class CuisinesList
    {
        public IEnumerable<RecipeWithCuisines> Recipes { get; set; }
        public IEnumerable<CuisineUIO> Cuisines { get; set; }
        public string SelectedCuisineName { get; set; }
        public PaginationInfo PaginationInfo { get; set; }
    }
}
