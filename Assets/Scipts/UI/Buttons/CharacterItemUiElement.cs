using UnityEngine;
using Brawler.Characters;
using Brawler.Music;
using Brawler.Pooling;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Brawler.UI
{
    public class CharacterItemUiElement : BaseUiElement<Character>
    {
        public override Component Component { get { return this; } }

        [SerializeField] private Image _image;

        private MusicManager _musicManager;

        public override void Init(Character character, CallBack<Character> callBack)
        {
            base.Init(character, callBack);

            transform.name = string.Format("Selecting: {0}", Item.CharacterInfo.CharacterName);
            Text.text = Item.CharacterInfo.CharacterName;
            _image.sprite = character.CharacterPortrait;

            _musicManager = MusicManager.Instance;

            BaseButton.OnPointerEnterCallBack += OnPointerEnter;
            BaseButton.OnPointerExitCallBack += OnPointerExit;
            BaseButton.OnPointerClickCallBack += OnPointerClick;
        }

        private void OnPointerExit(PointerEventData pointerEventData)
        {
            
        }

        private void OnPointerEnter(PointerEventData pointerEventData)
        {
            
        }

        private void OnPointerClick(BaseEventData baseEventData)
        {
            _musicManager.PlayClip(Item.CharacterClips.SelectSound);
        }

        public override void OnDisable()
        {
            PoolManager.Instance.ReturnToPool(this);
        }
    }
}