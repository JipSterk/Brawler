using System;
using System.Linq;
using Brawler.CustomInput;
using Brawler.GameSettings;
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
        [SerializeField] private JoyStickAxises _joyStickAxises;
        [SerializeField] private GameObject _firstSelected;
        [SerializeField] private InterfaceMenu _lastInterfaceMenu;

        private EventSystem _eventSystem;
        private JoyStickAxis _joystick1LeftHorizontal;
        private JoyStickButton _joystick1BackButton;
        private GameManager _gameManager;
        private bool _isActive;
        
        public void Init(UiButton[] uiButtons, Callback<MenuState> callback)
        {
            _gameManager = GameManager.Instance;
            _eventSystem = EventSystem.current;
            _joystick1LeftHorizontal = new JoyStickAxis(_joyStickAxises);
            _joystick1BackButton = new JoyStickButton(JoyStickButtons.Joystick1Back, "Back");

            foreach (var uiButton in uiButtons.Where(x => x.MenuState == _menuState))
                uiButton.Init(callback);
        }

        private void Update()
        {
            if(CustomInputManager.GetButtonDown(_joystick1BackButton) && _lastInterfaceMenu != null)
                _gameManager.UpdateMenuState(_lastInterfaceMenu.MenuState);

            if (Math.Abs(CustomInputManager.GetAxis(_joystick1LeftHorizontal)) < 0 || _isActive)
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