﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookASP.ViewComponents
{
    public class EditStepViewComponent : ViewComponentBase<EditStepViewComponent>
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
