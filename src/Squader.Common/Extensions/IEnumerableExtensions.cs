using System;
using System.Collections.Generic;
using System.Text;

namespace Squader.Common.Extensions
{
    public static class IEnumerableExtensions
    {

        
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source, IEqualityComparer<T> comparer = null)
        {
                return new HashSet<T>(source, comparer);
        }
        
    }
}
