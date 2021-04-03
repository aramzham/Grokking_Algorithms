using System;
using System.Linq;
using System.Threading;
using Common;

namespace SelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = new string('-', 30);

            while (true)
            {
                var array = RandomGenerator.GetRandomArray(0, 100, 10);
                Console.WriteLine($"unordered = {array.Stringify()}");
                var sorted = SelectionSort(array);
                Console.WriteLine($"sorted = {sorted.Stringify()}");
                var sorted_2 = SelectionSort_2(array);
                Console.WriteLine($"sorted_2 = {sorted_2.Stringify()}");

                Console.WriteLine(line);

                Thread.Sleep(5000); 
            }

            Console.ReadLine();
        }

        public static int[] SelectionSort(int[] unordered)
        {
            var ordered = new int[unordered.Length];
            var currentIndex = 0;
            var usedIndexes = Enumerable.Repeat(-1, unordered.Length).ToArray();

            while (currentIndex != unordered.Length)
            {
                var indexOfMin = GetIndexOfMin(unordered, usedIndexes);
                ordered[currentIndex++] = unordered[indexOfMin];
                usedIndexes[currentIndex - 1] = indexOfMin;
            }

            return ordered;
        }

        public static int GetIndexOfMin(int[] array, int[] usedIndexes)
        {
            var index = 0;
            var min = int.MaxValue;
            for (int i = 0; i < array.Length; i++)
            {
                if(Array.IndexOf(usedIndexes, i) != -1)
                    continue;

                if (array[i] < min)
                {
                    index = i;
                    min = array[i];
                }
            }

            return index;
        }

        public static int[] SelectionSort_2(int[] arr)
        {
            int smallest, temp;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                // find the smallest item starting from current index
                smallest = FindSmallest(arr, i);
                if (smallest == i) 
                    continue;

                // if it was not the smallest => swap it with smallest
                temp = arr[smallest];
                arr[smallest] = arr[i];
                arr[i] = temp;
            }

            return arr;
        }

        private static int FindSmallest(int[] arr, int currentIndex)
        {
            var smallest = currentIndex;
            for (int j = currentIndex + 1; j < arr.Length; j++)
            {
                if (arr[j] < arr[smallest])
                {
                    smallest = j;
                }
            }

            return smallest;
        }
    }
}
