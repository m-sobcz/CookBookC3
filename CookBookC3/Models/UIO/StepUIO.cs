using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookASP.Models
{
    public class StepUIO :UIO
    {
        public int Id { get; set; }
        [Display(Name = "Opis")]
        [Required(ErrorMessage = ErrorMessageText)]
        public static string Description { get; set; }
        [Display(Name = "Kolejność")]
        [Required(ErrorMessage = ErrorMessageText)]
        public int Order { get; set; }
    }
}
