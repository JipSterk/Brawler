using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Brawler.CustomInput;
using Brawler.GameManagement;
using Brawler.GameSettings;
using Brawler.LevelManagment;

namespace Brawler.Characters
{
    public class CharacterManager : MonoBehaviour
    {
        public static CharacterManager Instance { get { return _instance ?? new GameObject("Character Manager").AddComponent<CharacterManager>(); } }
        public List<Character> AllCharacters { get { return _allCharacters; } }

        [SerializeField] private List<Character> _allCharacters = new List<Character>();

        private static CharacterManager _instance;
        private SettingsManager _settingsManager;

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
            _settingsManager = SettingsManager.Instance;

            GameManager.Instance.OnMatchStart += SetupCharacters;
        }

        private void SetupCharacters(GamePlayer player1, GamePlayer player2, Level level, MatchSettings matchSettings)
        {
            InstantiateCharacter(player1.Character, player1.PlayerControlsProfile, level.Player1SpawnPoint);
            InstantiateCharacter(player2.Character, player2.PlayerControlsProfile, level.Player2SpawnPoint);
        }

        public void InstantiateCharacter(Character character, PlayerControlsProfile playerControlsProfile, LevelSpawnPoint levelSpawnPoint)
        {
            var tempCharacter = Instantiate(character, levelSpawnPoint.transform.position, Quaternion.identity, levelSpawnPoint.transform);
            tempCharacter.Init(playerControlsProfile, _settingsManager.Settings.CharacterOutline);
        }

        public void InstantiateRandomCharacter(PlayerControlsProfile playerControlsProfile, LevelSpawnPoint levelSpawnPoint)
        {
            var tempCharacter = Instantiate(_allCharacters.Random(), levelSpawnPoint.transform.position, Quaternion.identity, levelSpawnPoint.transform);
            tempCharacter.Init(playerControlsProfile, _settingsManager.Settings.CharacterOutline);
        }
        
        public List<Character> UnlockedCharacters()
        {
            return _allCharacters.Where(x => x.CharacterInfo.IsUnlocked).ToList();
        }

        public List<CharacterInfo> CharacterInfos()
        {
            return _allCharacters.Select(x => x.CharacterInfo).ToList();
        }

        public Character GetCharacter(string characterName)
        {
            return _allCharacters.First(x => x.CharacterInfo.CharacterName == characterName);
        }

        public void UnlockCharacter(string characterName)
        {
            _allCharacters.First(x => x.CharacterInfo.CharacterName == characterName).CharacterInfo.SetUnlocked();
        }
    }
}