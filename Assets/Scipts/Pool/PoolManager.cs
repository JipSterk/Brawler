using System;
using System.Collections.Generic;
using UnityEngine;

namespace Brawler.Pooling
{
    public class PoolManager : MonoBehaviour
    {
        public static PoolManager Instance { get { return _instance ?? new GameObject("Pool Manager").AddComponent<PoolManager>(); } }

        private static PoolManager _instance;
        private Dictionary<Type, Pool> _pools = new Dictionary<Type, Pool>();
        
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
        
        public Pool CreatePool(IPoolAble iPoolAble, int count = 20, Transform parent = null)
        {
            if (_pools.ContainsKey(iPoolAble.Component.GetType()))
                return _pools[iPoolAble.Component.GetType()];

            if (!parent)
            {
                parent = new GameObject(iPoolAble.Component.name).transform;
                parent.SetParent(transform);
            }

            var pool = new Pool(iPoolAble.Component, parent, count);
            _pools.Add(iPoolAble.Component.GetType(), pool);
            return pool;
        }

        public Component GetFromPool(Type type)
        {
            return _pools[type].GetFromPool();
        }

        public void ReturnToPool(IPoolAble iPoolAble)
        {
            if(!_pools.ContainsKey(iPoolAble.Component.GetType()))
                return;

            _pools[iPoolAble.Component.GetType()].AddToPool(iPoolAble.Component);
        }
    }
}