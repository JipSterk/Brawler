using System.Collections.Generic;
using UnityEngine;

namespace Brawler.UI.Extentions
{
    public static class UiExtentions
    {
        public static void InstantiateAllElements<T>(this List<T> list, CallBack<T> callBack, BaseUiElement<T> baseUiElement, Transform parent)
        {
            foreach (var item in list)
            {
                var element = Object.Instantiate(baseUiElement, parent);
                element.Init(item, callBack);
            }
        }
    }
}