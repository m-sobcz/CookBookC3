using CookBookASP.Controllers;
using CookBookASP.Extensions;
using CookBookASP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookASP.Components
{
    public class EditTabsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string viewName,int tabId)
        {
            return View(viewName, tabId);
        }
    }
}