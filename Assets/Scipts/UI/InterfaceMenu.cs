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

        private EventSystem _eventSystem;
        private JoyStickAxis _joystick1LeftHorizontal;
        private bool _isActive;
        
        public void Init(UiButton[] uiButtons, CallBack<MenuState> callBack)
        {
            _eventSystem = EventSystem.current;
            _joystick1LeftHorizontal = new JoyStickAxis(_joyStickAxises);

            foreach (var button in uiButtons.Where(uiButton => uiButton.MenuState == _menuState))
                button.Init(callBack);
        }

        private void Update()
        {
            if (CustomInputManager.GetAxis(_joystick1LeftHorizontal) == 0 || _isActive)
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