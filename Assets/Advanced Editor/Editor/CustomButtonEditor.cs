using Brawler.GameSettings;
using Brawler.UI;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Brawler.AdvacedEditor
{
    public class CustomButtonEditor : ScriptableWizard
    {
        [SerializeField] private MenuState _menuState;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private int _heigth = 60;
        [SerializeField] private int _width = 320;
        [SerializeField] private int _fontSize = 28;
        [SerializeField] private Sprite _sprite;

        [MenuItem("Brawler/Create Button")]
        private static void CreateWizard()
        {
            DisplayWizard<CustomButtonEditor>("New Button", "Create");
        }

        private void OnWizardCreate()
        {
            var uiButton = new GameObject(_menuState.ToString())
            {
                layer = _layerMask.value
            };
            var layoutElement = uiButton.AddComponent<LayoutElement>();
            layoutElement.preferredHeight = _heigth;

            var uiButtonRectTransform = uiButton.GetComponent<RectTransform>();
            uiButtonRectTransform.sizeDelta = new Vector2(_width, _heigth);

            var uibutton = uiButton.AddComponent<UiButton>();
            uibutton.MenuState = _menuState;

            var button = new GameObject("Button");
            button.transform.SetParent(uiButton.transform);

            var buttonRect = button.AddComponent<RectTransform>();
            buttonRect.anchorMax = new Vector2(1, 1);
            buttonRect.anchorMin = new Vector2(0, 0);
            buttonRect.sizeDelta = Vector2.zero;

            var image = button.AddComponent<Image>();
            image.type = Image.Type.Sliced;
            image.sprite = _sprite;

            button.AddComponent<Button>();

            var textobj = new GameObject("Text");
            textobj.transform.SetParent(button.transform);

            var textRextTransform = textobj.AddComponent<RectTransform>();
            textRextTransform.anchorMax = new Vector2(1, 1);
            textRextTransform.anchorMin = new Vector2(0, 0);
            textRextTransform.sizeDelta = Vector2.zero;
            
            var text = textobj.AddComponent<Text>();
            text.text = _menuState.ToString();
            text.fontSize = _fontSize;
            text.color = Color.black;
            text.alignment = TextAnchor.MiddleCenter;
        }
    }
}