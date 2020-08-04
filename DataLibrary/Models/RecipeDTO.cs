using System;
using System.Collections.Generic;
using System.Text;

namespace CookBookBLL.Models
{
    public class RecipeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Time { get; set; }
        public int Portions { get; set; }
    }
}
