using System;
using UnityEngine;

namespace Brawler.GameManagement
{
    [Serializable]
    public struct MatchSettings
    {
        public int GameTime { get { return _gameTime; } }
        public MatchMode MatchMode { get { return _matchMode; } }
        public float RespawnTime { get { return _respawnTime; } }
        public float ItemDespawnTime { get { return _itemDespawnTime; } }

        [SerializeField] private int _gameTime;
        [SerializeField] private MatchMode _matchMode;
        [SerializeField] [Range(0f, 10f)] private float _respawnTime;
        [SerializeField] [Range(0f, 10f)] private float _itemDespawnTime;
    }
}