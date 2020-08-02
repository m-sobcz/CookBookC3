using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookASP.Models
{
    public class IngredientWithCountUIO : IngredientUIO
    {
        [Display(Name = "Ilość")]
        public decimal Count { get; set; }
    }
}
