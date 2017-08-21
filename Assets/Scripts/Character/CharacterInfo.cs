using System;
using UnityEngine;

namespace Brawler.Characters
{
    [Serializable]
    public class CharacterInfo
    {
        public string CharacterName { get { return _characterName; } }
        public float TotalTimePlayed { get { return _totalTimePlayed; } }
        public int TimesPlayed { get { return _timesPlayed; } }
        public int TimesWon { get { return _timesWon; } }
        public int TimesLost { get { return _timesLost; } }
        public bool IsUnlocked { get { return _isUnlocked; } }
        public int Cost { get { return _cost; } }

        [SerializeField] private string _characterName;
        [SerializeField] private float _totalTimePlayed;
        [SerializeField] private int _timesPlayed;
        [SerializeField] private int _timesWon;
        [SerializeField] private int _timesLost;
        [SerializeField] private bool _isUnlocked;
        [SerializeField] private int _cost;

        public bool SetUnlocked()
        {
            return _isUnlocked = true;
        }
    }
}