using System;
using System.Linq;

namespace LongestCommon
{
    class Program
    {
        static void Main(string[] args)
        {
            var s1 = "zxabcdezy";
            var s2 = "yzabcdezx";
            var longestCommonSubstring = LongestCommonSubstring(s1, s2);
            var longestCommonSubsequence = LongestCommonSubsequence(s1, s2);
            Console.WriteLine($"{nameof(longestCommonSubstring)} = {longestCommonSubstring}");
            Console.WriteLine($"{nameof(longestCommonSubsequence)} = {longestCommonSubsequence}");

            Console.ReadKey();
        }

        private static int LongestCommonSubsequence(string first, string second)
        {
            var matrix = new int[first.Length][];
            for (var i = 0; i < matrix.Length; i++)
                matrix[i] = new int[second.Length];

            var max = 0;

            for (int i = 0; i < first.Length; i++)
            {
                for (int j = 0; j < second.Length; j++)
                {
                    if (first[i] != second[j])
                        matrix[i][j] = i == 0 && j == 0
                            ? 0
                            : i == 0
                                ? matrix[i][j - 1]
                                : j == 0
                                    ? matrix[i - 1][j]
                                    : Math.Max(matrix[i - 1][j], matrix[i][j - 1]);
                    else
                    {
                        if (i == 0 || j == 0)
                            matrix[i][j] = 1;
                        else
                            matrix[i][j] = matrix[i - 1][j - 1] + 1;

                        if (max < matrix[i][j])
                            max = matrix[i][j];
                    }
                }
            }

            return max;
        }

        private static int LongestCommonSubstring(string first, string second)
        {
            var matrix = new int[first.Length][];
            for (var i = 0; i < matrix.Length; i++)
                matrix[i] = new int[second.Length];

            var max = 0;

            for (int i = 0; i < first.Length; i++)
            {
                for (int j = 0; j < second.Length; j++)
                {
                    if (first[i] != second[j])
                        matrix[i][j] = 0;
                    else
                    {
                        if (i == 0 || j == 0)
                            matrix[i][j] = 1;
                        else
                            matrix[i][j] = matrix[i - 1][j - 1] + 1;

                        if (max < matrix[i][j])
                            max = matrix[i][j];
                    }
                }
            }

            return max;
        }
    }
}
