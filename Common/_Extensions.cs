using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public static class _Extensions
    {
        public static string Stringify<T>(this IEnumerable<T> list)
        {
            var sb = new StringBuilder();
            sb.Append('[');
            sb.AppendJoin(',', list);
            sb.Append(']');
            return sb.ToString();
        }

        public static T[] SubArray<T>(this T[] array, int offset, int length)
        {
            T[] result = new T[length];
            Array.Copy(array, offset, result, 0, length);
            return result;
        }
    }
}