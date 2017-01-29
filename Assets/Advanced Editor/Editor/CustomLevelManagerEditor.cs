using Brawler.LevelManagment;
using UnityEditor;

namespace Brawler.AdvacedEditor
{
    [CustomEditor(typeof(LevelManager))]
    public class CustomLevelManagerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var myTarget = (LevelManager)target;

            foreach (var level in myTarget.AllLevels)
                level.Name = level.LevelData.LevelName;
        }
    }
}