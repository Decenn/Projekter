using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringExtension
{
    public static class StringExtensions
    {
        public static string Capitalize(this string str) => str.Substring(0, 1).ToUpper() + str.Substring(1, str.Length-1).ToLower();
    }
}
