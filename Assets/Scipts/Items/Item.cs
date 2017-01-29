using UnityEngine;
using System.Collections;
using Brawler.Characters;
using Brawler.GameSettings;

namespace Brawler.Items
{
    [RequireComponent(typeof(SphereCollider))]
    public class Item : MonoBehaviour
    {
        public bool IsActive { get { return _isActive; } }
        public ItemData ItemData { get { return _itemData; } }

        private bool _isActive;
        private ItemData _itemData;
        private float _despawnTime;
        private Character _character;

        public void Load(ItemData itemData)
        {
            _itemData = itemData;
        }

        public void SetActive()
        {
            _isActive = true;
        }

        public void Init()
        {
            _despawnTime = GameManager.Instance.MatchSettings.ItemDespawnTime;
            transform.name = string.Format("Item: {0}", _itemData.ItemName);
            StartCoroutine(Despawn());
        }

        private void OnTriggerEnter(Collider c)
        {
            _character = c.GetComponent<Character>();
            StopCoroutine(Despawn());
        }

        private void ItemDrop()
        {
            StartCoroutine(Despawn());
        }

        private IEnumerator Despawn()
        {
            while (_despawnTime > 0)
            {
                yield return null;
                _despawnTime -= Time.deltaTime;
            }

            Destroy(gameObject);
        }
    }
}