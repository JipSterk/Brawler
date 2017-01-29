using UnityEngine;

namespace Brawler.LevelManagment
{
    public class LevelSpawnPoint : MonoBehaviour
    {
        public Vector3 Position { get { return transform.position; } }
        public LevelSpawnPointType LevelSpawnPointType { get { return _levelSpawnPointType; } }

        [SerializeField] private LevelSpawnPointType _levelSpawnPointType;

        public void Init(Vector3 position, LevelSpawnPointType levelSpawnPointType)
        {
            transform.position = position;
            _levelSpawnPointType = levelSpawnPointType;
        }
    }
}