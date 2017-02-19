using System.Collections.Generic;
using System.Linq;

namespace Brawler
{
    public static class RandomExtentions
    {
        public static T Random<T>(this IEnumerable<T> iEnumerable)
        {
            var array = iEnumerable.ToArray();
            return array[UnityEngine.Random.Range(0, array.Length)];
        }
    }
}