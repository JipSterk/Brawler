using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Brawler.UI
{
    public abstract class BaseUiElement<T> : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Text _text;

        protected T _t;
        private event CallBack<T> CallBack;
        
        public virtual void Init(T t, CallBack<T> callBack)
        {
            _t = t;

            if(callBack == null || _button == null)
                return;

            CallBack = callBack;
            _button.onClick.AddListener(() => CallBack(_t));
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