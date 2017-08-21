using System;
using Brawler.GameSettings;
using UnityEngine;
using UnityEngine.UI;

namespace Brawler.UI
{
    public class UiButton : MonoBehaviour
    {
        public MenuState MenuState { get { return _menuState; } set { _menuState = value; } }
        public Button Button { get { return _button; } }

        [SerializeField] private MenuState _menuState;
    
        private Button _button;
        
        public void Init(Action<MenuState> callback)
        {
            _button = GetComponentInChildren<Button>();
            _button.onClick.RemoveAllListeners();
            _button.onClick.AddListener(() => callback(_menuState));
        }
    }
}