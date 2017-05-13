using Brawler.LevelManagement;
using UnityEditor;

namespace Brawler.AdvacedEditor
{
    [CustomEditor(typeof(LevelManager))]
    public class CustomLevelManagerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            foreach (var level in ((LevelManager)target).AllLevels)
                level.Name = level.LevelData.LevelName;
        }
    }
}