using UnityEngine;
using Brawler.Characters;
using UnityEngine.UI;

namespace Brawler.UI
{
    public class CharacterSelectUiElement : BaseUiElement<Character>
    {
        [SerializeField] private Image _image;

        private CharacterSelectElement _characterSelectElement;

        public override void Init(Character character, CallBack<Character> callBack)
        {
            base.Init(character, callBack);

            transform.name = string.Format("Selecting: {0}", Item.CharacterInfo.CharacterName);
            SetText(Item.CharacterInfo.CharacterName);
            _image.sprite = character.CharacterPortrait;
        }
    }
}