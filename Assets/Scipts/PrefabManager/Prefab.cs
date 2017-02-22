using System;
using UnityEngine;

namespace Brawler.Prefabs
{
    [Serializable]
    public struct Prefab
    {
        public string Name { get { return _name; } }
        public string[] Tags { get { return _tags; } }
        public GameObject Object { get { return _object; } }

        [SerializeField] private string _name;
        [SerializeField] private GameObject _object;
        [SerializeField] private string[] _tags;
    }
}