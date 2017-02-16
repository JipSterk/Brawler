using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Brawler.Characters;
using Brawler.GameManagement;
using Brawler.GamePlay;
using Brawler.Items;
using Brawler.LevelManagment;
using Brawler.Networking;
using Brawler.SaveLoad;

namespace Brawler.GameSettings
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get { return _instance; } }
        public MatchSettings MatchSettings { get { return _matchSettings; } }
        public PlayerOnlineInfo PlayerOnlineInfo { get { return _playerOnlineInfo; } }
        public MenuState MenuState { get { return _menuState; } }
        public List<Item> ActiveItems { get { return _activeItems; } }
        public Announcer Announcer { get { return _announcer; } }

        public event CallBack<GamePlayer, GamePlayer, List<Item>, Level> OnStartMatch;
        public event CallBack<MatchSettings> OnMatchSettingsUpdate;
        public event CallBack<MenuState> OnUpdateMenuState;

        [SerializeField] private MatchSettings _matchSettings;
        [SerializeField] private MatchSettings _defaultMatchSettings;
        [SerializeField] private PlayerOnlineInfo _playerOnlineInfo;
        [SerializeField] private GameCamera _gameCameraPrefab;

        private static GameManager _instance;
        private MenuState _menuState;
        private Announcer _announcer;
        private Level _level;
        private List<Item> _activeItems = new List<Item>();
        private GamePlayer _player2;
        private GamePlayer _player1;

        private void Awake()
        {
            if (_instance)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            _announcer = GetComponent<Announcer>();
            
            SaveLoadManager.Instance.WhenSaveFileExist += LoadPlayerOnlineInfo;
            StartCoroutine(Init());
        }

        private IEnumerator Init()
        {
            _matchSettings = _defaultMatchSettings;
            yield return null;
            UpdateMenuState(MenuState.TitleScreen);
        }

        public void UpdateMatchSettings(MatchSettings matchSettings)
        {
            _matchSettings = matchSettings;

            if (OnMatchSettingsUpdate != null)
                OnMatchSettingsUpdate(_matchSettings);
        }

        public void UpdateMenuState(MenuState menuState)
        {
            _menuState = menuState;

            if (OnUpdateMenuState != null)
                OnUpdateMenuState( _menuState);
        }

        public void AddPlayer(GamePlayer gamePlayer, SelectingForPlayer selectingForPlayer)
        {
            switch (selectingForPlayer)
            {
                case SelectingForPlayer.Player1:
                    _player1 = gamePlayer;
                    break;
                case SelectingForPlayer.Player2:
                    _player2 = gamePlayer;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("selectingForPlayer", selectingForPlayer, null);
            }
        }

        public void StartMatch(Level level)
        {
            StartCoroutine(StartMatchInternal(level));
        }

        public IEnumerator StartMatchInternal(Level level)
        {
            _level = level;
            _activeItems = ItemManager.Instance.AllActiveItems;
            
            yield return StartCoroutine(LevelManager.Instance.LoadLevelAsync(_level));
            _level.SetupSpawnPoints();
            
            if (OnStartMatch != null)
                OnStartMatch(_player1, _player2, _activeItems, _level);

            SetupGameCamera();

            CharacterManager.Instance.InstantiateCharacter(_player1.Character, _player1.PlayerControlsProfile, _level.Player1SpawnPoint);
            CharacterManager.Instance.InstantiateCharacter(_player2.Character, _player2.PlayerControlsProfile, _level.Player2SpawnPoint);
        }

        private void LoadPlayerOnlineInfo(SaveData saveData)
        {
            _playerOnlineInfo = saveData.PlayerOnlineInfo;
        }

        private void SetupGameCamera()
        {
            var gameCamera = Instantiate(_gameCameraPrefab, new Vector3(0, 0, -10), Quaternion.identity);
            gameCamera.Init(_player1.Character, _player2.Character);
        }
    }
} 