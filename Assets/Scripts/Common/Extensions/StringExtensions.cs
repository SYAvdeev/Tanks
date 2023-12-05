using System;

namespace Common.Extensions
{
    public static class StringExtensions
    {
        public static string Remove(this string sourceString, string removeString)
        {
            int index = sourceString.IndexOf(removeString, StringComparison.Ordinal);
            string cleanPath = (index < 0)
                ? sourceString
                : sourceString.Remove(index, removeString.Length);

            return cleanPath;
        }
    }
}