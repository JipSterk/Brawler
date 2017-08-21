using UnityEngine;

namespace Brawler.LevelManagement
{
    public class LevelSpawnPoint : MonoBehaviour
    {
        public LevelSpawnPointType LevelSpawnPointType { get { return _levelSpawnPointType; } }

        [SerializeField] private LevelSpawnPointType _levelSpawnPointType;

        public void Init(Vector3 position, LevelSpawnPointType levelSpawnPointType)
        {
            transform.position = position;
            _levelSpawnPointType = levelSpawnPointType;
        }
    }
}