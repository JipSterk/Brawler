using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Brawler.CustomInput;
using Brawler.GameSettings;
using Brawler.LevelManagment;
using Brawler.Characters;
using Brawler.Networking;
using Steamworks;

namespace Brawler.SaveLoad
{
    public class SaveLoadManager : MonoBehaviour
    {
        public static SaveLoadManager Instance { get { return _instance ?? new GameObject("Save Load Manager").AddComponent<SaveLoadManager>(); } }

        public event CallBack<SaveData> WhenSaveFileExist;
        public event CallBack GatherAllData;

        private static SaveLoadManager _instance;

        [SerializeField] private string _saveDataName = "Savegame.dat";

        private string _saveDataPath;
        private SaveData _saveData;

        public void Awake()
        {
            if (_instance)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        public void Start()
        {
            Init();
        }

        private void Init()
        {
            _saveDataPath = string.Format("{0}/{1}", Application.dataPath, _saveDataName);
            GatherAllData += GatherData;

            if (File.Exists(_saveDataPath))
                LoadFromDisk();
            else
                CreateFirstSave();
            
            if (WhenSaveFileExist != null)
                WhenSaveFileExist(_saveData);
        }

        private void CreateFirstSave()
        {
            var allPlayerControlsProfiles = PlayerControlManager.Instance.PlayerControlsProfiles;
            var allCharacterInfos = CharacterManager.Instance.CharacterInfos();
            var allLevels = LevelManager.Instance.LevelDatas();
            var playerInfo = new PlayerOnlineInfo(SteamFriends.GetPersonaName(), SteamUtils.GetIPCountry());
            var settings = SettingsManager.Instance.DefaultSettings;

            _saveData = new SaveData(allPlayerControlsProfiles, allCharacterInfos, allLevels, playerInfo, settings);
            SaveToDisk(_saveData);
        }

        public void GatherData()
        {
            var allPlayerControlsProfiles = PlayerControlManager.Instance.PlayerControlsProfiles;
            var allCharacterInfos = CharacterManager.Instance.CharacterInfos();
            var allLevels = LevelManager.Instance.LevelDatas();
            var playerOnlineInfo = GameManager.Instance.PlayerOnlineInfo;
            var settings = SettingsManager.Instance.Settings;
            
            _saveData = new SaveData(allPlayerControlsProfiles, allCharacterInfos, allLevels, playerOnlineInfo, settings);
            SaveToDisk(_saveData);
        }

        private void SaveToDisk(SaveData saveData)
        {
            var binaryFormatter = new BinaryFormatter();
            var stream = new FileStream(_saveDataPath, FileMode.Create);
            binaryFormatter.Serialize(stream, saveData);
            stream.Close();
        }

        private void LoadFromDisk()
        {
            var binaryFormatter = new BinaryFormatter();
            var stream = new FileStream(_saveDataPath, FileMode.Open);
            _saveData = (SaveData) binaryFormatter.Deserialize(stream);
            stream.Close();
        }

        private void DeleteSaveGame()
        {
            File.Delete(_saveDataPath);
        }
    }
}