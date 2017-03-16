using System;
using UnityEngine;

namespace Brawler.Prefabs
{
    [Serializable]
    public struct Prefab
    {
        public string Name { get { return _name; } }
        public GameObject GameObject { get { return _gameObject; } }
        public string[] Tags { get { return _tags; } }

        [SerializeField] private string _name;
        [SerializeField] private GameObject _gameObject;
        [SerializeField] private string[] _tags;
    }
}