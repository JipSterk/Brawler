using System;
using System.Collections.Generic;

namespace Brawler.Extentions
{
    public static class ListExtentions
    {
        public static void Shuffle<T>(this T[] array)
        {
            var random = new Random();
            var length = array.Length;

            for (var i = 0; i < length; i++)
            {
                var index = i + (int) (random.NextDouble() * (length - i));
                var item = array[i];
                array[index] = array[i];
                array[i] = item;
            }
        }

        public static void Shuffle<T>(this List<T> list)
        {
            var random = new Random();
            var length = list.Count;

            for (var i = 0; i < length; i++)
            {
                var index = i + (int) (random.NextDouble() * (length - i));
                var item = list[i];
                list[index] = list[i];
                list[i] = item;
            }
        }
    }
}