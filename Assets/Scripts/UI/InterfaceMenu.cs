using System;
using System.Linq;
using Brawler.GameSettings;
using Rewired;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Brawler.UI
{
    public class InterfaceMenu : MonoBehaviour
    {
        public MenuState MenuState { get { return _menuState; } }
        public InterfaceMenuLoadMode InterfaceMenuLoadMode { get { return _interfaceMenuLoadMode; } }
        
        [SerializeField] private MenuState _menuState;
        [SerializeField] private InterfaceMenuLoadMode _interfaceMenuLoadMode;
        [SerializeField] private GameObject _firstSelected;
        
        private GameManager _gameManager;
        private EventSystem _eventSystem;
        private Player _player;
        private bool _isActive;
        
        public void Init(UiButton[] uiButtons, Action<MenuState> callback)
        {
            _eventSystem = EventSystem.current;
            _gameManager = GameManager.Instance;
            _player = ReInput.players.GetPlayer(0);

            foreach (var uiButton in uiButtons.Where(x => x.MenuState == _menuState))
                uiButton.Init(callback);
        }

        private void Update()
        {
            if (_player.GetButtonDown("UICancel"))
                _gameManager.LoadLastMenuState();
            
            if (Mathf.Abs(_player.GetAxis("UIVertical")) < 0 || _isActive)
                return;

            _eventSystem.SetSelectedGameObject(_firstSelected);
            _isActive = true;
        }

        private void OnDisable()
        {
            _isActive = false;
        }
    }
}