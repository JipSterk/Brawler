using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

namespace Brawler.Extensions
{
    public static class ListExtensions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            var count = list.Count;
            var random = new Random();

            while (count > 1)
            {
                count--;
                var index = random.Next(count + 1);
                var value = list[index];
                list[index] = list[count];
                list[count] = value;
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