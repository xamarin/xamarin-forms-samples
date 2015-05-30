using System;
using System.Collections.Generic;

namespace BoxViewClock
{
    public static class IListExtensions
    {
        public static IList<T> AddRange<T>(this IList<T> dest, IEnumerable<T> source)
        {
            if(dest == null || source == null)
            {
                return dest;
            }

            foreach(T t in source)
            {
                dest.Add(t);
            }
            return dest;
        }
    }
}
