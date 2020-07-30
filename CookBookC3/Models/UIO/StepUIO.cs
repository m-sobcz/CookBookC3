using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookASP.Models
{
    public class StepUIO :UIOBase
    {
        public int Id { get; set; }
        public int Recipe_Id { get; set; }
        [Display(Name = "Opis")]
        [Required(ErrorMessage = ErrorMessageText)]
        public string Description { get; set; }
        [Display(Name = "Kolejność")]
        public int Order { get; set; }
    }
}
