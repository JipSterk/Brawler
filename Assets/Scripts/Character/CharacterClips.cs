using System;
using Brawler.Music;
using UnityEngine;

namespace Brawler.Characters
{
    [Serializable]
    public struct CharacterClips
    {
        public MusicClip SelectSound { get { return _selectSound; } }

        [SerializeField] private MusicClip _selectSound;
    }
}