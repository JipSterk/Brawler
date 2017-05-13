using System;
using UnityEngine;

namespace Brawler.GameManagement
{
    [Serializable]
    public struct MatchSettings
    {
        public int GameTime { get { return _gameTime; } }
        public bool AllowPauseMenu { get { return _allowPauseMenu; } }
        public MatchMode MatchMode { get { return _matchMode; } }
        
        [SerializeField] private int _gameTime;
        [SerializeField] private bool _allowPauseMenu;
        [SerializeField] private MatchMode _matchMode;
        
    }
}