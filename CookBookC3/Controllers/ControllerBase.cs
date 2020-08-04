using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookASP.Controllers
{
    public abstract class ControllerBase<T> : Controller
    {
        public static T names;
    }
}
