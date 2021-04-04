using System;
using System.Linq;
using System.Threading;
using Common;

namespace QuickSort
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var unorderedArray = RandomGenerator.GetRandomArray(0, 100, 10);
                var ordered = QSort(unorderedArray);
                Console.WriteLine($"Was {unorderedArray.Stringify()}, became {ordered.Stringify()}");
                Thread.Sleep(3000);
            }
        }

        private static int[] QSort(int[] array)
        {
            if (array.Length < 2)
                return array;

            // var pivot = array[0]; // not the best choice as complexion may grow up to O(n x n) depending on it
            var pivotTuple = GetRandomPivot(array); // this will bring our average (pivot, index)
            var lessThans = GetLessOnes(array, pivotTuple.Item1);
            var greaterOrEqualThans = GetGreaterOrEqualOnes(array, pivotTuple);
            return Merge(QSort(lessThans), new[] { pivotTuple.Item1 }, QSort(greaterOrEqualThans));
        }

        private static (int, int) GetRandomPivot(int[] array)
        {
            var index = RandomGenerator.GetRandomNumber(0, array.Length);
            var pivot = array[index];
            return (pivot, index);
        }

        private static int[] GetGreaterOrEqualOnes(int[] array, (int, int) pivotTuple) => array.Where((x, i) => x >= pivotTuple.Item1 && i != pivotTuple.Item2).ToArray();

        private static int[] GetLessOnes(int[] array, int pivot) => array.Where(x => x < pivot).ToArray();

        private static int[] Merge(params int[][] arrays)
        {
            var result = new int[arrays.Sum(x => x.Length)];
            var index = 0;
            for (int i = 0; i < arrays.Length; i++)
            {
                for (int j = 0; j < arrays[i].Length; j++)
                {
                    result[index++] = arrays[i][j];
                }
            }

            return result;
        }
    }
}
