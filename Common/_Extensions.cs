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
            foreach (var item in list)
            {
                sb.Append(item);
                sb.Append(',');
            }

            sb.Remove(sb.Length - 1, 1);
            sb.Append(']');
            return sb.ToString();
        }
    }
}