using System;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace Brawler.LevelManagement
{
    [Serializable]
    public class Level
    {
        [HideInInspector] public string Name;

        public LevelData LevelData { get { return _levelData; } }
        public Sprite LevelSprite { get { return _levelSprite; } }
        public Object Scene { get { return _scene; } }
        public LoadSceneMode LoadSceneMode { get { return _loadSceneMode; } }
        public LevelSpawnPoint Player1SpawnPoint { get { return _player1SpawnPoint; } }
        public LevelSpawnPoint Player2SpawnPoint { get { return _player2SpawnPoint; } }
        public LevelSpawnPoint[] LevelItemSpawnPoints { get { return _levelItemSpawnPoints; } }

        [SerializeField] private LevelData _levelData;
        [SerializeField] private Sprite _levelSprite;
        [SerializeField] private Object _scene;
        [SerializeField] private LoadSceneMode _loadSceneMode;

        private LevelSpawnPoint _player1SpawnPoint;
        private LevelSpawnPoint _player2SpawnPoint;
        private LevelSpawnPoint[] _levelItemSpawnPoints;

        public void Load(LevelData levelData)
        {
            _levelData = levelData;
        }

        public void SetupSpawnPoints()
        {
            var levelSpawnPoints = Object.FindObjectsOfType<LevelSpawnPoint>();
            _player1SpawnPoint = levelSpawnPoints.First(x => x.LevelSpawnPointType == LevelSpawnPointType.Player1);
            _player2SpawnPoint = levelSpawnPoints.First(x => x.LevelSpawnPointType == LevelSpawnPointType.Player2);
        }
    }
}   