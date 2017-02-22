using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Brawler.SaveLoad;
using UnityEngine.SceneManagement;

namespace Brawler.LevelManagment
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance { get { return _instance; } }
        public List<Level> AllLevels { get { return _allLevels; } }
        public Level CurrentLevel { get { return _currentLevel; } }

        public event CallBack<Level> OnLevelWasLoaded;

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
            var loadSceneAsync = SceneManager.LoadSceneAsync(_currentLevel.Scene.name);

            while (!loadSceneAsync.isDone)
                yield return null;
            
            if (OnLevelWasLoaded != null)
                OnLevelWasLoaded(_currentLevel);
        }
        
        private void LoadLevelsData(SaveData saveData)
        {
            foreach (var levelData in saveData.LevelsData)
                _allLevels.First(x => x.LevelData.LevelName == levelData.LevelName).Load(levelData);
        }

        public List<LevelData> LevelDatas()
        {
            return _allLevels.Select(level => level.LevelData).ToList();
        }

        public List<Level> UnlockedLevels()
        {
            return _allLevels.Where(level => level.LevelData.IsUnlocked).ToList();
        }

        public Level GetRandomLevel()
        {
            return _allLevels.Random();
        }

        public Level GetLevel(string levelName)
        {
            return _allLevels.First(x => x.LevelData.LevelName == levelName);
        }
    }
}