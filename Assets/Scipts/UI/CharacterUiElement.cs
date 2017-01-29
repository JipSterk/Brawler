using Brawler.Characters;
using UnityEngine;
using UnityEngine.UI;

namespace Brawler.UI
{
    public class CharacterUiElement : BaseUiElement<Character>
    {
        [SerializeField] private Image _characterImage;

        public override void Init(Character character, CallBack<Character> callBack)
        {
            _t = character;

            transform.name = string.Format("{0} UIProfile", _t.CharacterInfo.CharacterName);
            _characterImage.sprite = _t.CharacterPortrait;
            _t.OnCharacterDamage += UpdateCharacterInfoUi;
        }
        
        private void UpdateCharacterInfoUi(float procent)
        {
            SetText(string.Format("{0:P}", procent));
        }
    }
}