using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookBookASP.Extensions
{
    public static class StringsReplaceExtension
    {
        public static IEnumerable<string> ReplaceStrings(this IEnumerable<string> sequence, string oldValue, string newValue)
        {
            foreach (string sequencePart in sequence)
            {
                yield return sequencePart.Replace(oldValue, newValue);
            }
        }
    }
}
