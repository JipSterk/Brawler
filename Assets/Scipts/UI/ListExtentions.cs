using System.Collections;
using System.Collections.Generic;
using Brawler.UI;
using UnityEngine;

namespace Brawler.Extentions
{
    public static class ListExtentions
    {
        public static void DestroyAllChilderen(this IEnumerable parent)
        {
            foreach (Transform child in parent)
                Object.Destroy(child.gameObject);
        }

        public static void DestoryAllChilderen(this Transform parent, int offset)
        {
            for (var i = offset; i < parent.childCount; i++)
                Object.Destroy(parent.GetChild(i).gameObject);
        }

        public static void ToggleAllChilderen(this IEnumerable parent, bool active)
        {
            foreach (Transform child in parent)
                child.gameObject.SetActive(active);
        }

        public static void ToggleAllChilderen(this Transform parent, bool active, int offset)
        {
            for (var i = offset; i < parent.childCount; i++)
                parent.GetChild(i).gameObject.SetActive(active);
        }
    }
}