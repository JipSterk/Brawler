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
            Item = character;

            transform.name = string.Format("{0} UIProfile", Item.CharacterInfo.CharacterName);
            _characterImage.sprite = Item.CharacterPortrait;
            Item.OnCharacterDamage += UpdateCharacterInfoUi;
        }
        
        private void UpdateCharacterInfoUi(float procent)
        {
            SetText(string.Format("{0:P}", procent));
        }
    }
}