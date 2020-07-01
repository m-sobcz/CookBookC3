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
        [Display(Name = "Nazwa")]
        [Required(ErrorMessage = ErrorMessageText)]
        public string Name { get; set; }
        [Display(Name = "Opis")]
        [Required(ErrorMessage = ErrorMessageText)]
        public string Description { get; set; }
        [Display(Name = "Jednostka")]
        [Required(ErrorMessage = ErrorMessageText)]
        public string Unit { get; set; }
        [Display(Name = "Koszt")]
        [Required(ErrorMessage = ErrorMessageText)]
        public decimal Cost { get; set; }
        [Display(Name = "Kalorie")]
        [Required(ErrorMessage = ErrorMessageText)]
        public int Callories { get; set; }
        
        
    }
}
