using System;
using UnityEngine;
using System.Linq;
using Object = UnityEngine.Object;

namespace Brawler.LevelManagment
{
    [Serializable]
    public class Level
    {
        [HideInInspector] public string Name;

        public LevelData LevelData { get { return _levelData; } }
        public Sprite LevelSprite { get { return _levelSprite; } }
        public Object Scene { get { return _scene; } }
        public LevelSpawnPoint RespawnPoint { get { return _respawnPoint; } }
        public LevelSpawnPoint Player1SpawnPoint { get { return _player1SpawnPoint; } }
        public LevelSpawnPoint Player2SpawnPoint { get { return _player2SpawnPoint; } }
        public LevelSpawnPoint[] LevelItemSpawnPoints { get { return _levelItemSpawnPoints; } }

        [SerializeField] private LevelData _levelData;
        [SerializeField] private Sprite _levelSprite;
        [SerializeField] private Object _scene;

        private LevelSpawnPoint _respawnPoint;
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
            _respawnPoint = levelSpawnPoints.FirstOrDefault(spawnPoint => spawnPoint.LevelSpawnPointType == LevelSpawnPointType.Respawn);
            _levelItemSpawnPoints = levelSpawnPoints.Where(spawnPoint => spawnPoint.LevelSpawnPointType == LevelSpawnPointType.Item).ToArray();
            _player1SpawnPoint = levelSpawnPoints.First(x => x.LevelSpawnPointType == LevelSpawnPointType.Player1);
            _player2SpawnPoint = levelSpawnPoints.First(x => x.LevelSpawnPointType == LevelSpawnPointType.Player2);
        }
    }
}   