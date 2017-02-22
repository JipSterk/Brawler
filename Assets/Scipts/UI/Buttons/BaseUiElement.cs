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
        
        public virtual void Init(T item, CallBack<T> callBack)
        {
            Item = item;
            BaseButton.onClick.AddListener(() => callBack(Item));
        }
        
        public abstract void OnDisable();
    }
}