using System;
using UnityEngine;

namespace Brawler.Items
{
    [Serializable]
    public class ItemData
    {
        public string ItemName { get { return _itemName; } set { _itemName = value; } }
        public ItemRarity ItemRarity { get { return _itemRarity; } set { _itemRarity = value; } }
        public Sprite ItemSprite { get { return _itemSprite; } set { _itemSprite = value; } }

        [SerializeField] private string _itemName;
        [SerializeField] private ItemRarity _itemRarity;
        [SerializeField] private Sprite _itemSprite;
    }
}