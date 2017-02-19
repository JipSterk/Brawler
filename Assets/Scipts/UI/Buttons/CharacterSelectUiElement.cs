using UnityEngine;
using Brawler.Characters;
using Brawler.Pooling;
using UnityEngine.UI;

namespace Brawler.UI
{
    public class CharacterSelectUiElement : BaseUiElement<Character>
    {
        public override Component Component { get { return this; } }

        [SerializeField] private Image _image;

        public override void Init(Character character, CallBack<Character> callBack)
        {
            base.Init(character, callBack);

            transform.name = string.Format("Selecting: {0}", Item.CharacterInfo.CharacterName);
            SetText(Item.CharacterInfo.CharacterName);
            _image.sprite = character.CharacterPortrait;
        }
        
        public override void OnDisable()
        {
            PoolManager.Instance.ReturnToPool(this);
        }
    }
}