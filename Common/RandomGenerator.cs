using System;
using System.Linq;

namespace Common
{
    public class RandomGenerator
    {
        private static readonly Random _r = new Random();

        public static int[] GetRandomArray(int min, int max, int size) => Enumerable
            .Repeat(0, size)
            .Select(i => _r.Next(min, max))
            .ToArray();

        public static int GetRandomNumber(int min, int max) => _r.Next(min, max);
    }
}
