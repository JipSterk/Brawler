using System;
using System.Collections.Generic;
using System.Linq;
using Brawler.Pooling;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Brawler.UI.Extentions
{
    public static class UiExtentions
    {
        private static readonly PoolManager PoolManager = PoolManager.Instance;

        public static void DestroyAllChildren(this Transform parent)
        {
            for (var i = 0; i < parent.childCount; i++)
                Object.Destroy(parent.GetChild(i).gameObject);
        }

        public static void DestoryAllChildren(this Transform parent, int offset)
        {
            for (var i = offset; i < parent.childCount; i++)
                Object.Destroy(parent.GetChild(i).gameObject);
        }

        public static void ToggleAllChildren(this Transform parent, bool value)
        {
            for (var i = 0; i < parent.childCount; i++)
                parent.GetChild(i).gameObject.SetActive(value);
        }

        public static void ToggleAllChildren(this Transform parent, bool value, int offset)
        {
            for (var i = offset; i < parent.childCount; i++)
                parent.GetChild(i).gameObject.SetActive(value);
        }

        public static void InstantiateAllUiElements<T>(this IList<T> list, Action<T> callback, BaseUiElement<T> baseUiElement, Transform parent)
        {
            var pool = PoolManager.CreatePool(baseUiElement, list.Count, parent);

            foreach (var item in list)
            {
                baseUiElement = (BaseUiElement<T>) pool.GetFromPool();
                baseUiElement.Init(item, callback);
            }
        }
    }
}