using System;
using System.Threading;
using Common;

namespace BinarySearchByRecursion
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var orderedArray = RandomGenerator.GetRandomArray(0, 50, 10);
                // this step is obligatory for binary search
                Array.Sort(orderedArray);
                var target = 20;
                var index = BinarySearchRec(orderedArray, target, 0, orderedArray.Length - 1);
                Console.WriteLine($"Index of {target} in {orderedArray.Stringify()} = {index}");
                Console.WriteLine($"BinarySearch says {Array.BinarySearch(orderedArray, 0, orderedArray.Length, 20)}");
                Thread.Sleep(1000);
            }
        }

        public static int BinarySearchRec(int[] array, int target, int low, int high)
        {
            if (low > high)
                return -1;

            var middle = (low + high) / 2;

            if (target > array[middle])
                return BinarySearchRec(array, target, middle + 1, high);
            else if (target < array[middle])
                return BinarySearchRec(array, target, low, middle - 1);
            else
                return middle;
        }
    }
}
