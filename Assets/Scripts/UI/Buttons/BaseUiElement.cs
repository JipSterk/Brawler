using System;
using Brawler.Pooling;
using UnityEngine;
using UnityEngine.UI;

namespace Brawler.UI
{
    public abstract class BaseUiElement<T> : MonoBehaviour, IPoolAble
    {
        public abstract Component Component { get; }

        [SerializeField] protected BaseButton BaseButton;
        [SerializeField] protected Text Text;

        protected T Item;
        
        public virtual void Init(T item, Action<T> callback)
        {
            Item = item;
            BaseButton.onClick.AddListener(() => callback(Item));
        }
        
        public abstract void OnDisable();
    }
}