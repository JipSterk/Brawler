using System.Collections.Generic;

namespace Brawler
{
    public static class RandomExtentions
    {
        public static T Random<T>(this IList<T> list)
        {
            return list[UnityEngine.Random.Range(0, list.Count)];
        }
    }
}