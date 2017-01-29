using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Brawler.LevelManagment;

namespace Brawler.Items
{
    public class ItemManager : MonoBehaviour
    {
        public List<Item> AllActiveItems { get { return GetAllActiveItems(); } }
        public static ItemManager Instance { get { return _instance; } }

        [SerializeField] private Item _itemPrefab;

        private static ItemManager _instance;
        private List<Item> _allItems = new List<Item>();

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

        
        public void SpawnItem(Item item)
        {
            var tempItem = Instantiate(item, GetRandomPosition(), Quaternion.identity, transform);
            tempItem.Init();
        }

        public void SpawnRandomItem()
        {
            var tempItem = Instantiate(GetRandomItem(), GetRandomPosition(), Quaternion.identity, transform);
            tempItem.Init();
        }

        private List<Item> GetAllActiveItems()
        {
            return _allItems.Where(item => item.IsActive).ToList();
        }

        private Item GetRandomItem()
        {
            return _allItems[Random.Range(0, _allItems.Count)];
        }

        private Vector3 GetRandomPosition()
        {
            var spawnPoints = LevelManager.Instance.CurrentLevel.LevelItemSpawnPoints;
            return spawnPoints[Random.Range(0, spawnPoints.Length)].Position;
        }

        public ItemData GetItemData(string itemName)
        {
            return _allItems.Select(x => x.ItemData).FirstOrDefault(y => y.ItemName == itemName);
        }

        public Item GetItem(string itemName)
        {
            return _allItems.First(x => x.ItemData.ItemName == itemName);
        }
    }
}