using System.ComponentModel.DataAnnotations;

namespace CookBookASP.Models
{
    public class CuisineUIO : UIOBase
    {
        public int Id { get; set; }
        [Display(Name = "Nazwa")]
        [Required(ErrorMessage = ErrorMessageText)]
        public string Name { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }
    }
}
