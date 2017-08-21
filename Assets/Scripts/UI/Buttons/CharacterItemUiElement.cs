using System;
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

        private void Start()
        {
            BaseButton.OnPointerEnterCallback += OnPointerEnter;
            BaseButton.OnPointerExitCallback += OnPointerExit;
            BaseButton.OnPointerClickCallback += OnPointerClick;
        }

        public override void Init(Character character, Action<Character> callback)
        {
            base.Init(character, callback);

            transform.name = string.Format("Selecting: {0}", Item.CharacterInfo.CharacterName);

            Text.text = Item.CharacterInfo.CharacterName;
            _image.sprite = character.CharacterPortrait;
        }

        private void OnPointerExit(PointerEventData pointerEventData)
        {
            
        }

        private void OnPointerEnter(PointerEventData pointerEventData)
        {
            
        }

        private void OnPointerClick(BaseEventData baseEventData)
        {
            MusicManager.Instance.PlayClip(Item.CharacterClips.SelectSound);
        }

        public override void OnDisable()
        {
            PoolManager.Instance.ReturnToPool(this);
        }
    }
}