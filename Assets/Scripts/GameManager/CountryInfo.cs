using System;
using UnityEngine;

namespace Brawler.GameSettings
{
    [Serializable]
    public class CountryInfo
    {
        public Sprite CountrySprite { get { return _countrySprite; } }

        [HideInInspector] public string Name;
        [SerializeField] private Sprite _countrySprite;
    }
}