using System;
using UnityEngine;

namespace Brawler.LevelManagement
{
    [Serializable]
    public struct LevelData
    {
        public LevelData(string levelName, bool isUnlocked)
        {
            _levelName = levelName;
            _isUnlocked = isUnlocked;
        }

        public string LevelName { get { return _levelName; } }
        public bool IsUnlocked { get { return _isUnlocked; } }

        [SerializeField] private string _levelName;
        [SerializeField] private bool _isUnlocked;
    }
}