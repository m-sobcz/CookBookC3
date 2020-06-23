using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookC3.Extensions
{
    public static class StringsReplace
    {
        public static IEnumerable<string> StringReplace(this IEnumerable<string> sequence, string oldValue, string newValue)
        {
            foreach (string sequencePart in sequence)
            {
                yield return sequencePart.Replace(oldValue, newValue);
            }
        }
    }
}
