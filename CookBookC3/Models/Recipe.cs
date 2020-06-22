using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookC3.Models
{
    public class Recipe
    {
        public string Name { get; set; }
        public int Time { get; set; }
        public int Portions { get; set; }
        public List<string> Steps { get; set; }
        public List<Tuple<Ingredient, int>> Ingredients { get; set; }
    }
}
