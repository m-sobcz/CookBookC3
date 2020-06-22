using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookC3.Models
{
    public class PageInfo
    {
        public int ItemsCount { get; set; }
        public int ItemsPerPage { get; set; }
        public int Current { get; set; }


        public int PagesCount => (int)Math.Ceiling((decimal)ItemsCount/ItemsPerPage);

    }
}
