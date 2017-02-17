using System.Collections.Generic;
using System.Linq;
using Brawler.Pooling;
using UnityEngine;

namespace Brawler.UI.Extentions
{
    public static class UiExtentions
    {
        public static void InstantiateAllElements<T>(this List<T> list, CallBack<T> callBack, BaseUiElement<T> baseUiElement, Transform parent)
        {
            var pool = PoolManager.Instance.CreatePool(baseUiElement, list.Count, parent);

            foreach (var item in list)
            {
                var baseElement = (BaseUiElement<T>)pool.GetFromPool();
                baseElement.Init(item, callBack);
            }
            //foreach (var item in list)
            //{
            //    var element = Object.Instantiate(baseUiElement, parent);
            //    element.Init(item, callBack);
            //}
        }
    }
}