using System;
using System.Collections.Generic;
using System.Text;

namespace CookBookBLL.Models
{
    public class StepDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public int Recipe_Id { get; set; }
    }
}
