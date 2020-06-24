using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookC3.Extensions
{
    public static class ControllerExtensions
    {
        public static string ControllerName(this Type controllerType)
        {
            Type baseType = typeof(Controller);
            if (baseType.IsAssignableFrom(controllerType))
            {
                int lastControllerIndex = controllerType.Name.LastIndexOf("Controller");
                if (lastControllerIndex > 0)
                {
                    return controllerType.Name.Substring(0, lastControllerIndex);
                }
            }

            return controllerType.Name;
        }
    }
}
