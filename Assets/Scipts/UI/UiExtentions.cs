using System.Collections;
using System.Collections.Generic;
using Brawler.Pooling;
using UnityEngine;

namespace Brawler.UI.Extentions
{
    public static class UiExtentions
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
        
        public static void InstantiateAllElements<T>(this List<T> list, CallBack<T> callBack, BaseUiElement<T> baseUiElement, Transform parent)
        {
            var pool = PoolManager.Instance.CreatePool(baseUiElement, list.Count, parent);

            foreach (var item in list)
            {
                var baseElement = (BaseUiElement<T>)pool.GetFromPool();
                baseElement.Init(item, callBack);
            }
        }
    }
}