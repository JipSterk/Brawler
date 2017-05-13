using Brawler.GameSettings;
using UnityEditor;

namespace Brawler.AdvacedEditor
{
    [CustomEditor(typeof(CountryInfoManager))]
    public class CustomCountryInfoEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            foreach (var countryInfo in ((CountryInfoManager)target).CountryInfos)
            {
                if(countryInfo.CountrySprite != null)
                    countryInfo.Name = countryInfo.CountrySprite.name;
            }
        }
    }
}