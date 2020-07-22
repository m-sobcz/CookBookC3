using CookBookASP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookASP.Models
{
    public class CategoryUIO : UIO
    {
        public int Id { get; set; }
        [Display(Name = "Nazwa")]
        [Required(ErrorMessage = ErrorMessageText)]
        public string Name { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }
    }
}
