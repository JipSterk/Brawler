using System.Collections;
using System.Collections.Generic;
using Brawler.UI;
using UnityEngine;

namespace Brawler.Extentions
{
    public static class ListExtentions
    {
        //public static void InstantiateAll<T>(this List<T> list, T prefab, Transform parent) where T : Object
        //{
        //    foreach (var item in list)
        //    {
        //        var tempObject = Object.Instantiate(prefab, parent);

        //        if (!(prefab is BaseUiElement<T>)) continue;
        //        tempObject.Init(item);
        //    }
        //}

        public static void DestoryAllChilderen(this Transform parent, int offset)
        {
            for (var i = offset; i < parent.childCount; i++)
                Object.Destroy(parent.GetChild(i).gameObject);
        }

        public static void DestroyAllChilderen(this IEnumerable parent)
        {
            foreach (Transform t in parent)
                Object.Destroy(t.gameObject);
        }
    }
}