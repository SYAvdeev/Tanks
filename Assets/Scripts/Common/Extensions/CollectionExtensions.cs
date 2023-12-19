using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Extensions
{
    public static class CollectionExtensions
    {
        public static T[] Shuffled<T>(this T[] source, Random random)
        {
            T[] shuffled = new T[source.Length];
            source.CopyTo(shuffled, 0);

            int len = source.Length;
            for (var i = 0; i < len - 1; i++)
            {
                int j = i + random.Next(len - i);
                (shuffled[j], shuffled[i]) = (shuffled[i], shuffled[j]);
            }

            return shuffled;
        }

        public static T[] Shuffled<T>(this T[] source, int length, Random random)
        {
            T[] array = Shuffled(source, random);
            Array.Resize(ref array, length);  
            return array;
        }
        
        public static T[] Shuffle<T>(this T[] array, Random random)
        {
            for (int index = 0, length = array.Length; index < length - 1; ++index)
            {
                int r = random.Next(0, length);
                (array[index], array[r]) = (array[r], array[index]);
            }

            return array;
        }
        
        public static T[] Shuffle<T>(this T[] array, int from, int count, Random random)
        {
            for (int index = from, length = index + count; index < length - 1; ++index)
            {
                int r = random.Next(from, length);
                (array[index], array[r]) = (array[r], array[index]);
            }

            return array;
        }
        
        public static IList<T> Shuffle<T>(this IList<T> list, Random random)
        {
            for (int index = 0, length = list.Count; index < length - 1; ++index)
            {
                int r = random.Next(0, length);
                (list[index], list[r]) = (list[r], list[index]);
            }

            return list;
        }
        
        public static IList<T> Shuffle<T>(this IList<T> list, int from, int count, Random random)
        {
            for (int index = from, length = index + count; index < length - 1; ++index)
            {
                int r = random.Next(from, length);
                (list[index], list[r]) = (list[r], list[index]);
            }

            return list;
        }
        public static T Random<T>(this IList<T> source, Random random) 
        {
            return source[random.Next(0, source.Count)];
        }

        public static bool ContainsAny<T>(this T[] array, T[] other)
        {
            for (int i = 0; i < other.Length; i++)
            {
                if (array.Contains(other[i]))
                {
                    return true;
                }
            }

            return false;
        }
    }
}