using System;
using System.Linq;
using Brawler.GameSettings;
using UnityEngine;

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

        public void Init(UiButton[] uiButtons)
        {
            foreach (var button in uiButtons.Where(uiButton => uiButton.MenuState == _menuState))
                button.Init(GameManager.Instance.UpdateMenuState);
        }
    }
}