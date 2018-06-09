using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Squader.Common.Extensions
{
    public static class StringExtensions
    {
        private static string emailPattern = "[A-Z0-9a-z._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}";
        public static bool IsEmail(this string str)
        {
            return Regex.IsMatch(str, emailPattern);
        }
    }
}
