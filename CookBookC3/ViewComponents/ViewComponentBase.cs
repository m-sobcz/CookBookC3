using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookASP.ViewComponents
{
    public abstract class ViewComponentBase<T> : ViewComponent
    {
        public static T names;
    }
}
