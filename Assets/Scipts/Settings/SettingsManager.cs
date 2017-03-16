using UnityEngine;
using Brawler.SaveLoad;

namespace Brawler.GameSettings
{
    public class SettingsManager : MonoBehaviour
    {
        public static SettingsManager Instance { get { return _instance ?? new GameObject("Settings Manager").AddComponent<SettingsManager>(); } }
        public Settings Settings { get { return _settings; } }
        public Settings DefaultSettings { get { return _defaultSettings; } }

        public event Callback<Settings> OnSettingsUpdate;

        [SerializeField] private Settings _settings;
        [SerializeField] private Settings _defaultSettings;

        private static SettingsManager _instance;
        
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
            SaveLoadManager.Instance.WhenSaveFileExist += LoadSettings;
        }

        public void UpdateSettingsState(Settings settings)
        {
            _settings = settings;

            if (OnSettingsUpdate != null)
                OnSettingsUpdate(_settings);
        }
        
        private void LoadSettings(SaveData saveData)
        {
            _settings = saveData.Settings;
        }
    }
}