using System;
using System.Linq;
using System.Threading;
using Common;

namespace SumByRecursion
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var array = RandomGenerator.GetRandomArray(0, 10, 5);
                var sum = Sum(array);
                Console.WriteLine($"{array.Stringify()}.Sum() = {sum}"); 
                Thread.Sleep(3000);
            }
        }

        public static int Sum(int[] array)
        {
            if (array.Length == 0)
                return 0;

            var firstElement = array[0];
            return firstElement + Sum(array.SubArray(1, array.Length - 1));
        }
    }
}
