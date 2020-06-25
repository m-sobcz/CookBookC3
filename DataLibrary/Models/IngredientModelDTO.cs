using System;
using System.Collections.Generic;
using System.Text;

namespace DataLibrary.Models
{
    public class IngredientModelDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public decimal CostPerUnit { get; set; }
        public int Callories { get; set; }
        public string Category { get; set; }
    }
}
