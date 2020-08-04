using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CookBookASP.Extensions
{
    public static class ASPNames
    {
        public static string GetASPName(this string originalName)
        {
            string result = Regex.Replace(originalName, @"ViewComponent|Controller", String.Empty);
            return result;
        }
        public static string GetASPNameNEW(this object nameSource)
        {
            string originalName = nameSource.GetType().Name;
            string result = Regex.Replace(originalName, @"ViewComponent|Controller", String.Empty);
            return result;
        }
    }
}
