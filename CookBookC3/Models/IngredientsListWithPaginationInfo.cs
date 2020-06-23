using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookC3.Models
{
    public class IngredientsListWithPaginationInfo
    {
        public IEnumerable<Ingredient> Ingredients { get; set; }
        public PaginationInfo PaginationInfo { get; set; }
    }
}
