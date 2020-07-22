using CookBookASP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookASP.Components
{
    public class RecipeEditTabViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(TabWithId model)
        {
            return View(model);
        }
    }
}



