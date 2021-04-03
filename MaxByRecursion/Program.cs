using System;
using System.Threading;
using Common;

namespace MaxByRecursion
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var array = RandomGenerator.GetRandomArray(0, 10, 5);
                var max = Max(array);
                Console.WriteLine($"{array.Stringify()}.Max() = {max}");
                Thread.Sleep(1000);
            }
        }

        public static int Max(int[] array)
        {
            if (array.Length == 1)
                return array[0];

            // max without first element
            var max = Max(array.SubArray(1, array.Length - 1));
            return max > array[0] ? max : array[0];
        }
    }
}
