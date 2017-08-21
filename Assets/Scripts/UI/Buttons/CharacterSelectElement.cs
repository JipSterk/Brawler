using System;
using Brawler.Characters;
using Brawler.GameManagement;
using Brawler.GameSettings;
using Brawler.Pooling;
using UnityEngine;
using UnityEngine.UI;

namespace Brawler.UI
{
    public class CharacterSelectElement : BaseUiElement<Character>
    {
        public override Component Component { get { return this; } }

        [SerializeField] private SelectingForPlayer _selectingForPlayer;
        [SerializeField] private Image _characterImage;
        [SerializeField] private Dropdown _playerProfileDropdown;

        public override void Init(Character character, Action<Character> callback)
        {
            base.Init(character, callback);

            //BaseButton.onClick.AddListener(() => UpdateCharacter(Item));
            //var playerProfiles = _playerControlsManager.PlayerControlsProfiles;
            //_playerProfileDropdown.AddOptions(playerProfiles.Select(x => new Dropdown.OptionData(x.ProfileName)).ToList());
        }

        private void UpdateCharacter(Character character)
        {
            _characterImage.sprite = character.CharacterPortrait;
            Text.text = character.CharacterInfo.CharacterName;
            
        }
        
        public override void OnDisable()
        {
            PoolManager.Instance.ReturnToPool(this);
        }
    }
}