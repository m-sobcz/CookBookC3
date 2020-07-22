using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookASP.Models
{
    public class IngredientUIO : UIO
    {
        public int Id { get; set; }
        [Display(Name = "Nazwa")]
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
