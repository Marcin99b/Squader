using System;
using System.Text.RegularExpressions;
using Squader.Common.CustomObjects;

namespace Squader.Common
{
    public static class GuidExtensions
    {
        public static ShortGuid ToShort(this Guid guid)
        {
            return Regex.Replace(Convert.ToBase64String(guid.ToByteArray()), "[/+=]", "");
        }
    }
}
