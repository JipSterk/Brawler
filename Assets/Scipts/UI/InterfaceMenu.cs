using System;
using System.Collections.Generic;
using System.Linq;
using Brawler.UI.Extentions;
using Brawler.GameSettings;
using UnityEngine;
using UnityEngine.UI;

namespace Brawler.UI
{
    [Serializable]
    public class InterfaceMenu
    {
        public MenuState MenuState { get { return _menuState; } }
        public InterfaceMenuLoadMode InterfaceMenuLoadMode { get { return _interfaceMenuLoadMode; } }
        public GameObject InterfacePanel { get { return _interfacePanel; } }

        [HideInInspector] public string Name;

        [SerializeField] private MenuState _menuState;
        [SerializeField] private InterfaceMenuLoadMode _interfaceMenuLoadMode;
        [SerializeField] private GameObject _interfacePanel;

        private List<UiButton> _buttons = new List<UiButton>();

        public void Init(UiButton[] uiButtons)
        {
            _buttons = uiButtons.Where(uiButton => uiButton.MenuState == _menuState).ToList();
            //_buttons.ForEach(button => button.GetComponentInChildren<Button>().onClick.RemoveAllListeners());

            _buttons.SetupMenuButtons(GameManager.Instance.UpdateMenuState);
        }
    }
}