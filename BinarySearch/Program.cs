using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Common;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var orderedArray = RandomGenerator.GetRandomArray(0, 50, 9);
                // this step is obligatory for binary search
                Array.Sort(orderedArray);
                var target = 20;
                var index = BinarySearch(orderedArray, target);
                Console.WriteLine($"Index of {target} in {orderedArray.Stringify()} = {index}");
                Console.WriteLine($"BinarySearch says {Array.BinarySearch(orderedArray, 0, orderedArray.Length, 20)}");
                Thread.Sleep(1000);
            }
        }

        public static int BinarySearch(int[] array, int target)
        {
            var low = 0;
            var high = array.Length - 1;
            var middle = -1;
            while (low <= high)
            {
                middle = (low + high) / 2;

                if (target > array[middle])
                    low = middle + 1;
                else if (target < array[middle])
                    high = middle - 1;
                else
                    return middle;
            }

            return -1;
        }
    }
}
