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
using Brawler.UI;

namespace Brawler.GameSettings
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get { return _instance; } }
        public MatchSettings MatchSettings { get { return _matchSettings; } }
        public PlayerOnlineInfo PlayerOnlineInfo { get { return _playerOnlineInfo; } }
        public MenuState MenuState { get { return _menuState; } }
        public List<Item> ActiveItems { get { return _activeItems; } }
        public List<GamePlayer> GamePlayers { get { return _gamePlayers; } }
        public Announcer Announcer { get { return _announcer; } }

        public event CallBack<List<GamePlayer>, List<Item>, Level> OnStartMatch;
        public event CallBack<MatchSettings> OnMatchSettingsUpdate;
        public event CallBack<MenuState> OnUpdateMenuState;

        [SerializeField] private MatchSettings _matchSettings;
        [SerializeField] private MatchSettings _defaultMatchSettings;
        [SerializeField] private PlayerOnlineInfo _playerOnlineInfo;
        [SerializeField] private MenuState _menuState;
        [SerializeField] private GameCamera _gameCameraPrefab;

        private static GameManager _instance;
        private Announcer _announcer;
        private Level _level;
        private List<Item> _activeItems = new List<Item>();
        private List<GamePlayer> _gamePlayers = new List<GamePlayer>();

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

        public void AddPlayer(GamePlayer gamePlayer)
        {
            _gamePlayers.Add(gamePlayer);
        }

        public IEnumerator StartMatch(Level level)
        {
            _level = level;
            _activeItems = ItemManager.Instance.AllActiveItems;

            if (OnStartMatch != null)
                OnStartMatch(_gamePlayers, _activeItems, _level);

            yield return StartCoroutine(LevelManager.Instance.LoadLevelAsync(_level));
            _level.SetupSpawnPoints();

            SetupGameCamera();

            for (var i = 0; i < _gamePlayers.Count; i++)
                CharacterManager.Instance.InstantiateCharacter(_gamePlayers[i].Character,
                    _gamePlayers[i].PlayerControlsProfile, _level.SpawnPoints[i]);
        }

        private void LoadPlayerOnlineInfo(SaveData saveData)
        {
            _playerOnlineInfo = saveData.PlayerOnlineInfo;
        }

        private void SetupGameCamera()
        {
            var gameCamera = Instantiate(_gameCameraPrefab, new Vector3(0, 0, -10), Quaternion.identity);
            gameCamera.Init(_gamePlayers);
        }
    }
} 