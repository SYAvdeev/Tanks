using System;

namespace ReactiveTypes.Extensions
{
    public static class ReactiveTypesExtensions
    {
        public static T Random<T>(this IReactiveListReadOnly<T> source, Random random) 
        {
            return source[random.Next(0, source.Count)];
        }
    }
}