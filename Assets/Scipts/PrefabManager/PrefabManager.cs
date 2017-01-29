using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Brawler.Prefabs
{
    public class PrefabManager : MonoBehaviour
    {
        public static PrefabManager Instance { get { return _instance; } }

        private static PrefabManager _instance;

        [SerializeField] private List<Prefab> _prefabs = new List<Prefab>();

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

        public List<Prefab> GetPrefabsByTags(string[] prefabTags)
        {
            return (from x in _prefabs from y in x.Tags where prefabTags.Any(z => z == y) select x).ToList();
        }

        public List<Prefab> GetPrefabsByTag(string prefabTag)
        {
            return _prefabs.Where(x => x.Tags.Any(y => y == prefabTag)).ToList();
        }

        public Prefab GetPrefabByTag(string prefabTag)
        {
            return _prefabs.First(x => x.Tags.Any(y => y == prefabTag));
        }

        public Prefab GetPrefabByName(string prefabName)
        {
            return _prefabs.First(x => x.Tags.Any(y => y == prefabName));
        }
    }
}