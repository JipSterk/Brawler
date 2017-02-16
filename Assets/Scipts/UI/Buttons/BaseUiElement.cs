using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Brawler.UI
{
    public abstract class BaseUiElement<T> : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Text _text;

        protected T Item;
        private event CallBack<T> CallBack;
        
        public virtual void Init(T item, CallBack<T> callBack)
        {
            Item = item;

            if(callBack == null || _button == null)
                return;

            CallBack = callBack;
            _button.onClick.AddListener(() => CallBack(Item));
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
    }
}