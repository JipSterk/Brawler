using Brawler.UI;
using UnityEditor;

namespace Brawler.AdvacedEditor
{
    [CustomEditor(typeof(InterfaceManager))]
    public class CustomInterfaceManagerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            var myTarget = (InterfaceManager) target;

            foreach (var interfaceMenu in myTarget.InterfaceMenus)
                interfaceMenu.Name = interfaceMenu.MenuState.ToString();
        }
    }
}