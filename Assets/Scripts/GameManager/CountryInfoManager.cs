using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Brawler.GameSettings
{
    [CreateAssetMenu(menuName = "Country Infos")]
    public class CountryInfoManager : ScriptableObject
    {
        public List<CountryInfo> CountryInfos { get { return _countryInfos; } }

        [SerializeField] private List<CountryInfo> _countryInfos = new List<CountryInfo>();

        public Sprite GetCountrySprite(string countryName)
        {
            return _countryInfos.First(x => x.CountrySprite.name == countryName).CountrySprite;
        }

        public CountryInfo GetCountryInfo(string countryName)
        {
            return _countryInfos.First(x => x.CountrySprite.name == countryName);
        }
    }
}