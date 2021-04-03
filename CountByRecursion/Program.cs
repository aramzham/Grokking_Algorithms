using System;
using System.Threading;
using Common;

namespace CountByRecursion
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var array = RandomGenerator.GetRandomArray(0, 10, RandomGenerator.GetRandomNumber(0, 11));
                var count = Count(array);
                Console.WriteLine($"{array.Stringify()}.Count() = {count}");
                Thread.Sleep(1000);
            }
        }

        public static int Count(int[] array)
        {
            if (array.Length == 0)
                return 0;

            return 1 + Count(array.SubArray(1, array.Length - 1));
        }
    }
}
