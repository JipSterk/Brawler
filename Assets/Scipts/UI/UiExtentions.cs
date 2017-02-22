using System.Collections;
using System.Collections.Generic;
using Brawler.Pooling;
using UnityEngine;
using UnityEngine.UI;

namespace Brawler.UI.Extentions
{
    public static class UiExtentions
    {
        private static PoolManager _poolManager = PoolManager.Instance;

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

        public static void ToggleAllChilderen(this Transform parent, bool value)
        {
            foreach (Transform child in parent)
                child.gameObject.SetActive(value);
        }

        public static void ToggleAllChilderen(this Transform parent, bool value, int offset)
        {
            for (var i = offset; i < parent.childCount; i++)
                parent.GetChild(i).gameObject.SetActive(value);
        }

        public static void InstantiateAllElements<T>(this List<T> list, CallBack<T> callBack, BaseUiElement<T> baseUiElement, Transform parent)
        {
            var pool = _poolManager.CreatePool(baseUiElement, list.Count, parent);

            foreach (var item in list)
            {
                var baseElement = (BaseUiElement<T>)pool.GetFromPool();
                baseElement.Init(item, callBack);
            }
        }
    }
}