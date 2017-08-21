using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Brawler.GameManagement;
using Brawler.GamePlay;
using Brawler.LevelManagement;
using Brawler.Networking;
using Brawler.SaveLoad;

namespace Brawler.GameSettings
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get { return _instance ?? new GameObject("Game Manager").AddComponent<GameManager>(); } }
        public MenuState MenuState { get { return _menuState; } }
        public MatchSettings MatchSettings { get { return _matchSettings; } }
        public PlayerOnlineInfo PlayerOnlineInfo { get { return _playerOnlineInfo; } }
        
        public event Action<GamePlayer, GamePlayer, Level, MatchSettings> OnMatchStart;
        public event Action<MatchSettings> OnMatchSettingsUpdate;
        public event Action<MenuState> OnUpdateMenuState;
        public event Action OnMatchEnd;

        [SerializeField] private MatchSettings _matchSettings;
        [SerializeField] private MatchSettings _defaultMatchSettings;
        [SerializeField] private PlayerOnlineInfo _playerOnlineInfo;
        [SerializeField] private GameCamera _gameCameraPrefab;

        private static GameManager _instance;
        private readonly List<MenuState> _lastMenuStates = new List<MenuState>();
        private MenuState _menuState;
        private Level _level;
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
            //Cursor.visible = false;
            //Cursor.lockState = CursorLockMode.Locked;
        
            SaveLoadManager.Instance.WhenSaveFileExist += LoadPlayerOnlineInfo;
            _matchSettings = _defaultMatchSettings;
            StartCoroutine(Init());
        }

        private IEnumerator Init()
        {
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
            if(!_lastMenuStates.Contains(menuState))
                _lastMenuStates.Add(menuState);

            _menuState = menuState;

            if (OnUpdateMenuState != null)
                OnUpdateMenuState(_menuState);
        }

        public void LoadLastMenuState()
        {
            if(_lastMenuStates.Count <= 0)
                return;

            var menuState = _lastMenuStates.Last();
            UpdateMenuState(menuState);
            _lastMenuStates.Remove(menuState);
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
        
        private IEnumerator StartMatchInternal(Level level)
        {
            _level = level;
            
            yield return StartCoroutine(LevelManager.Instance.LoadLevelAsync(_level));
            _level.SetupSpawnPoints();
            
            if (OnMatchStart != null)
                OnMatchStart(_player1, _player2, _level, _matchSettings);

            SetupGameCamera();
            UpdateMenuState(MenuState.OfflineMultiPlayer);
        }

        private void EndMatch()
        {
            if (OnMatchEnd != null)
                OnMatchEnd();
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