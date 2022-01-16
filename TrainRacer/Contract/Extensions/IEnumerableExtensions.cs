using System;
using System.Collections.Generic;
using System.Linq;

namespace TrainRacer.Contract.Extensions
{
    public static class IEnumerableExtensions
    {
        private static readonly Random _random = new();

        public static T? GetRandom<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable?.TryGetNonEnumeratedCount(out var count) == true)
            {
                return enumerable.ElementAtOrDefault(_random.Next(count));
            }
            return default;
        }
    }
}
