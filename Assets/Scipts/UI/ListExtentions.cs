using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

namespace Brawler.Extentions
{
    public static class ListExtentions
    {
        private static readonly Random Random = new Random();
        
        public static void Shuffle<T>(this IList<T> list)
        {
            var length = list.Count;

            for (var i = 0; i < length; i++)
            {
                var index = i + (int) (Random.NextDouble() * (length - i));
                var item = list[i];
                list[index] = list[i];
                list[i] = item;
            }
        }

        public static List<T> FindObjectsOfTypeAll<T>()
        {
            var list = new List<T>();
            for (var i = 0; i < SceneManager.sceneCount; i++)
            {
                var scene = SceneManager.GetSceneAt(i);
                if (!scene.isLoaded)
                    continue;

                foreach (var gameObject in scene.GetRootGameObjects())
                    list.AddRange(gameObject.GetComponentsInChildren<T>(true));
            }
            return list;
        }
    }
}