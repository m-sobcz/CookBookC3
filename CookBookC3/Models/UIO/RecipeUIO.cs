using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookASP.Models
{
    public class RecipeUIO : UIO
    {
        public int Id { get; set; }
        [Display(Name = "Nazwa")]
        [Required(ErrorMessage = ErrorMessageText)]
        public string Name { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }
        [Display(Name = "Czas przygotowania")]
        [Required(ErrorMessage = ErrorMessageText)]
        public int Time { get; set; }
        [Display(Name = "Porcje")]
        [Required(ErrorMessage = ErrorMessageText)]
        public int Portions { get; set; }
    }
}
