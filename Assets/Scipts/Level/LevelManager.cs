using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Brawler.SaveLoad;
using UnityEngine.SceneManagement;

namespace Brawler.LevelManagment
{
    public delegate void OnLevelWasLoaded(Level level);

    public class LevelManager : MonoBehaviour
    {
        public Level CurrentLevel { get { return _currentLevel; } }
        public List<Level> AllLevels { get { return _allLevels; } }
        public List<Level> UnlockedLevels { get { return GetUnlockedLevels(); } }
        public List<LevelData> AllLevelDatas { get { return GetLevelData(); } }
        public static LevelManager Instance { get { return _instance; } }
        
        public event OnLevelWasLoaded OnLevelWasLoaded;

        [SerializeField] private List<Level> _allLevels = new List<Level>();

        private static LevelManager _instance;
        private Level _currentLevel;

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

        public void Start()
        {
            SaveLoadManager.Instance.WhenSaveFileExist += LoadLevelsData;
        }
        
        public IEnumerator LoadLevelAsync(Level level)
        {
            _currentLevel = level;
            var asyncOperation = SceneManager.LoadSceneAsync(_currentLevel.Scene.name);

            while (!asyncOperation.isDone)
                yield return null;
            
            if (OnLevelWasLoaded != null)
                OnLevelWasLoaded(_currentLevel);
        }

        public IEnumerator LoadRandomLevelAsync()
        {
            var level = GetRandomLevel();
            _currentLevel = level;
            var asyncOperation = SceneManager.LoadSceneAsync(_currentLevel.Scene.name);

            while (!asyncOperation.isDone)
                yield return null;

            if (OnLevelWasLoaded != null)
                OnLevelWasLoaded(_currentLevel);
        }

        private void LoadLevelsData(SaveData saveData)
        {
            for (var i = 0; i < saveData.LevelsData.Count; i++)
                _allLevels[i].Load(saveData.LevelsData[i]);
        }

        private List<LevelData> GetLevelData()
        {
            return _allLevels.Select(level => level.LevelData).ToList();
        }

        private List<Level> GetUnlockedLevels()
        {
            return _allLevels.Where(level => level.LevelData.IsUnlocked).ToList();
        }

        private Level GetRandomLevel()
        {
            return _allLevels[Random.Range(0, _allLevels.Count)];
        }

        public Level GetLevel(string levelName)
        {
            return _allLevels.First(x => x.LevelData.LevelName == levelName);
        }
    }
}