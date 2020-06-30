using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookC3.Models
{
    public class IngredientUIO
    {
       
        const string ErrorMessageText = "Podanie tego pola jest obowiązkowe";
        public int Id { get; set; }
        [Required(ErrorMessage = ErrorMessageText)]
        public string Name { get; set; }
        [Required(ErrorMessage = ErrorMessageText)]
        public string Description { get; set; }
        [Required(ErrorMessage = ErrorMessageText)]
        public string Unit { get; set; }
        [Required(ErrorMessage = ErrorMessageText)]
        public decimal Cost { get; set; }
        [Required(ErrorMessage = ErrorMessageText)]
        public int Callories { get; set; }
        
        
    }
}
