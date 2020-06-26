using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
    public class IngredientDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public decimal Cost { get; set; }
        public int Callories { get; set; }
    }
}
