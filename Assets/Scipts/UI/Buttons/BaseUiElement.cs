using Brawler.Pooling;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Brawler.UI
{
    public abstract class BaseUiElement<T> : MonoBehaviour, IPoolAble
    {
        public abstract Component Component { get; }

        [SerializeField] private Button _button;
        [SerializeField] private Text _text;

        protected T Item;
        
        public virtual void Init(T item, CallBack<T> callBack)
        {
            Item = item;
        
            if(callBack != null)
                _button.onClick.AddListener(() => callBack(Item));
        }

        protected virtual void AddListener(UnityAction unityAction)
        {
            _button.onClick.AddListener(unityAction);
        }

        protected virtual void RemoveListener(UnityAction unityAction)
        {
            _button.onClick.RemoveListener(unityAction);
        }

        protected virtual void RemoveAllListeners()
        {
            _button.onClick.RemoveAllListeners();
        }

        protected virtual void SetText(string text)
        {
            _text.text = text;
        }

        public abstract void OnDisable();
    }
}