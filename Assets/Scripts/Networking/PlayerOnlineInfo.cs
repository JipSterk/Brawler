using System;
using UnityEngine;

namespace Brawler.Networking
{
    [Serializable]
    public struct PlayerOnlineInfo
    {
        public string PlayerName { get { return _playerName; } }
        public int PlayerScore { get { return _playerScore; } }
        public string PlayerCounty { get { return _playerCountry; }}

        [SerializeField] private string _playerName;
        [SerializeField] private string _playerCountry;
        [SerializeField] private int _playerScore;
        
        public PlayerOnlineInfo(string playerName, string playerCountry)
        {
            _playerName = playerName;
            _playerCountry = playerCountry;
            _playerScore = 0;
        }

        public int ModifyPlayerScore(int amount)
        {
            return _playerScore += amount;
        }
    }
}