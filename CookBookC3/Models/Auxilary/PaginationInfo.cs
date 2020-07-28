using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookASP.Models
{
    public class PaginationInfo
    {
        public int ItemsCount { get; set; }
        public int ItemsPerPage { get; set; }
        public int Current { get; set; }
        public int PagesCount => (int)Math.Ceiling((decimal)ItemsCount/ItemsPerPage);

    }
}
