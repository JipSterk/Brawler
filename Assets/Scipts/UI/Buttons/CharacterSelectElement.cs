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
        
        private void Start()
        {
            //BaseButton.onClick.AddListener(() => UpdateCharacter(Item));
        }

        public override void Init(Character character, Callback<Character> callback)
        {
            base.Init(character, callback);
            
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