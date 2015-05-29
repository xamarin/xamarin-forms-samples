using System;
using System.Linq;
using System.Collections.Generic;
namespace BoxViewClock.Helpers
{
    public static class IEnumerableHelpers
    {
        public static IEnumerable<T> Repeat<T>(Func<T> func, int count)
        {
            return Enumerable.Range(0, count).Select(_ => func());
        }

        public static IEnumerable<T> Repeat<T>(Func<int, T> func, int count)
        {
            return Enumerable.Range(0, count).Select(func);
        }
    }
}
