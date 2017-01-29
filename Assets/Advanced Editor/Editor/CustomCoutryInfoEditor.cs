using Brawler.GameSettings;
using UnityEditor;

namespace Brawler.AdvacedEditor
{
    [CustomEditor(typeof(CountryInfoManager))]
    public class CustomCoutryInfoEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var myTarget = (CountryInfoManager) target;

            foreach (var countryInfo in myTarget.CountryInfos)
            {
                if(countryInfo.CountrySprite != null)
                countryInfo.Name = countryInfo.CountrySprite.name;
            }
        }
    }
}