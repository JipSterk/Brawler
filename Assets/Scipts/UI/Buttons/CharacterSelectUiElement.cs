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

            transform.name = string.Format("Selecting: {0}", _t.CharacterInfo.CharacterName);
            SetText(_t.CharacterInfo.CharacterName);
            _image.sprite = character.CharacterPortrait;
        }
    }
}