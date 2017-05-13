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
        [SerializeField] private int _height = 60;
        [SerializeField] private int _width = 320;
        [SerializeField] private int _fontSize = 28;
        [SerializeField] private Sprite _sprite;

        [MenuItem("Brawler/Create BaseButton")]
        private static void CreateWizard()
        {
            DisplayWizard<CustomButtonEditor>("New BaseButton", "Create");
        }

        private void OnWizardCreate()
        {
            var uiButton = new GameObject(_menuState.ToString())
            {
                layer = _layerMask.value
            };

            var layoutElement = uiButton.AddComponent<LayoutElement>();
            layoutElement.preferredHeight = _height;

            var uiButtonRectTransform = uiButton.GetComponent<RectTransform>();
            uiButtonRectTransform.sizeDelta = new Vector2(_width, _height);

            var uibutton = uiButton.AddComponent<UiButton>();
            uibutton.MenuState = _menuState;

            var buttonGameObject = new GameObject("Button");
            buttonGameObject.transform.SetParent(uiButton.transform);

            var buttonRect = buttonGameObject.AddComponent<RectTransform>();
            buttonRect.anchorMax = new Vector2(1, 1);
            buttonRect.anchorMin = new Vector2(0, 0);
            buttonRect.sizeDelta = Vector2.zero;

            var image = buttonGameObject.AddComponent<Image>();
            image.type = Image.Type.Sliced;
            image.sprite = _sprite;

            buttonGameObject.AddComponent<Button>();

            var textGameObject = new GameObject("Text");
            textGameObject.transform.SetParent(buttonGameObject.transform);

            var textRectTransform = textGameObject.AddComponent<RectTransform>();
            textRectTransform.anchorMax = new Vector2(1, 1);
            textRectTransform.anchorMin = new Vector2(0, 0);
            textRectTransform.sizeDelta = Vector2.zero;
            
            var text = textGameObject.AddComponent<Text>();
            text.text = _menuState.ToString();
            text.fontSize = _fontSize;
            text.color = Color.black;
            text.alignment = TextAnchor.MiddleCenter;
        }
    }
}