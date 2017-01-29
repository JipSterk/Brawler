﻿using System;
using System.Linq;
using UnityEngine;
using Brawler.Characters;
using Brawler.CustomInput;
using Brawler.Extentions;
using Brawler.GameSettings;
using Brawler.LevelManagment;
using Brawler.Networking;
using Brawler.Steam;
using Brawler.UI.Extentions;
using Steamworks;
using UnityEngine.UI;

namespace Brawler.UI
{
    public class InterfaceManager : MonoBehaviour
    {
        public Transform InterfaceCanvasTransform { get { return _interfaceCanvasTransform; } }
        public InterfaceMenu[] InterfaceMenus { get { return _interfaceMenus; } }
        public static InterfaceManager Instance { get { return _instance ?? new GameObject("Interface Manager").AddComponent<InterfaceManager>(); } }

        [SerializeField] private CountryInfoManager _countryInfoManager;
        [SerializeField] private CharacterSelectUiElement _characterSelectUiElementPrefab;
        [SerializeField] private CharacterUiElement _characterUiElementPrefab;
        [SerializeField] private CharacterSelectElement _characterSelectElement;
        [SerializeField] private LevelUiElement _levelUiElementPrefab;
        [SerializeField] private PlayerProfileUiElement _playerProfileUiPrefab;
        [SerializeField] private InputField _matchNameInputField;
        [SerializeField] private InputField _matchPasswordInputField;
        [SerializeField] private InputField _newProfileNameInputField;
        [SerializeField] private Button _createMatchButton;
        [SerializeField] private Button _refreshMatchesButton;
        [SerializeField] private Button _quitButton;
        [SerializeField] private Text _outputText;
        [SerializeField] private Text _playerNameText;
        [SerializeField] private Text _versionNumberText;
        [SerializeField] private Image _avatarImage;
        [SerializeField] private Image _countyImage;
        [SerializeField] private Transform _characterElementParent;
        [SerializeField] private Transform _characterUiParent;
        [SerializeField] private Transform _characterSelectParent;
        [SerializeField] private Transform _levelElementParent;
        [SerializeField] private Transform _roomListParent;
        [SerializeField] private Transform _playerProfileParent;
        [SerializeField] private Transform _interfaceCanvasTransform;
        [SerializeField] private InterfaceMenu[] _interfaceMenus;

        private static InterfaceManager _instance;
        private GameObject[] _interfaceScreens;
        private GameManager _gameManager;
        private PlayerControlManager _playerControlManager;
        private CustomNetworkManager _customNetworkManager;
        
        private void Awake()
        {
            if (_instance)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
        }

        private void Start()
        {
            //todo keep track of all the players that are joined
            //todo then foreach player that joins make new profile and pass the characters to create ui elements
            _gameManager = GameManager.Instance;
            _customNetworkManager = CustomNetworkManager.Instance;
            _playerControlManager = PlayerControlManager.Instance;

            Init();
        }

        private void Init()
        {
            _gameManager.OnUpdateMenuState += UpdateMenuUi;

            _interfaceScreens = _interfaceMenus.Select(menu => menu.InterfacePanel).ToArray();

            _newProfileNameInputField.onEndEdit.AddListener(NamePlayerProfile);
            _quitButton.onClick.AddListener(Application.Quit);

            var allUiButtons = Resources.FindObjectsOfTypeAll<UiButton>();
            foreach (var interfaceMenu in _interfaceMenus)
                interfaceMenu.Init(allUiButtons);
        }

        public void InitNetworkUi(CallBack<string, string, bool> callback, CallBack callBack)
        {
            _createMatchButton.onClick.AddListener(() =>
            {
                callback(_matchNameInputField.text, _matchPasswordInputField.text, true);
                callBack();
            });
        }

        private void UpdateMenuUi(MenuState menuState)
        {
            UpdateUiPanels(InterfaceMenus.First(menu => menu.MenuState == menuState));

            switch (menuState)
            {
                case MenuState.TitleScreen:
                    break;
                case MenuState.Menu:
                    if(!_customNetworkManager.ConnectedToSteam)
                        return;

                    _playerNameText.text = _gameManager.PlayerOnlineInfo.PlayerName;
                    _versionNumberText.text = string.Format("Version: {0}", SteamAppList.GetAppBuildId(AppId_t.Invalid));
                    StartCoroutine(SteamUtilitys.FetchSteamInfo(_avatarImage, SteamUser.GetSteamID()));
                    _countyImage.sprite = _countryInfoManager.GetCountrySprite(_gameManager.PlayerOnlineInfo.PlayerCounty);
                    break;
                case MenuState.OnlineMultiplayer:
                    break;
                case MenuState.CharacterSelection:
                    var unlockedCharacters = CharacterManager.Instance.UnlockedCharacters();
                    _characterElementParent.DestroyAllChilderen();
                    unlockedCharacters.InstantiateAllElements(SelectCharacter, _characterSelectUiElementPrefab, _characterElementParent);
                    break;
                case MenuState.LevelSelection:
                    var unlockedLevels = LevelManager.Instance.UnlockedLevels;
                    _levelElementParent.DestroyAllChilderen();
                    unlockedLevels.InstantiateAllElements(SelectLevel, _levelUiElementPrefab, _levelElementParent);
                    break;
                case MenuState.MatchRules:
                    break;
                case MenuState.OfflineMultiplayer:
                    var activeCharacter = _gameManager.GamePlayers.Select(player => player.Character).ToList();
                    _characterUiParent.DestroyAllChilderen();
                    activeCharacter.InstantiateAllElements(null, _characterUiElementPrefab, _characterElementParent);
                    break;
                case MenuState.PlayerInput:
                    var playerControlsProfiles = PlayerControlManager.Instance.PlayerControlsProfiles;
                    for (int i = 1; i < _playerProfileParent.childCount; i++)
                        Destroy(_playerProfileParent.GetChild(i).gameObject);

                    playerControlsProfiles.InstantiateAllElements(LoadProfile, _playerProfileUiPrefab, _playerProfileParent);
                    break;
                case MenuState.SoundSettings:
                    break;
                case MenuState.FighterOutline:
                    break;
                case MenuState.DamageDisplay:
                    break;
                case MenuState.Quit:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("menuState", menuState, null);
            }
        }
        
        private void SelectLevel(Level level)
        {
            Debug.LogFormat("Selecting: {0}", level.LevelData.LevelName);
            StartCoroutine(_gameManager.StartMatch(level));
        }

        private void LoadProfile(PlayerControlsProfile playerControlsProfile)
        {
            Debug.Log("Loaded profile: " + playerControlsProfile.ProfileName);
        }

        private void SelectCharacter(Character character)
        {
            Debug.LogFormat("Selecting: {0}", character.CharacterInfo.CharacterName);
        }

        private void UpdateUiPanels(InterfaceMenu interfaceMenu)
        {
            switch (interfaceMenu.InterfaceMenuLoadMode)
            {
                case InterfaceMenuLoadMode.Single:
                    foreach (var g in _interfaceScreens)
                        g.SetActive(false);
                    break;
                case InterfaceMenuLoadMode.Addtive:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("interfaceMenu", interfaceMenu.InterfaceMenuLoadMode, null);
            }

            interfaceMenu.InterfacePanel.SetActive(true);
        }

        public void QuitGame()
        {
            Debug.Log("Quit");
            Application.Quit();
        }

        private void NamePlayerProfile(string profileName)
        {
            if (string.IsNullOrEmpty(profileName))
            {
                _outputText.text = "Please fill in a Profilename.";
                _newProfileNameInputField.text = null;
                return;
            }
            if (_playerControlManager.DoesProfileNameExist(profileName))
            {
                _outputText.text = "This name is taken.";
                _newProfileNameInputField.text = null;
                return;
            }

            var joystickIndex = _playerControlManager.GetJoyStickIndex();

            _playerControlManager.CreatePlayerControlsProfile(joystickIndex, profileName);
        }

        public InterfaceMenu GetInterfaceMenu(string interfaceMenuName)
        {
            return _interfaceMenus.First(x => x.Name == interfaceMenuName);
        }
    }
}