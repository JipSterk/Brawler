using System.Linq;
using Brawler.Characters;
using Brawler.CustomInput;
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
        
        private PlayerControlsProfile _playerControlsProfile;
        private PlayerControlManager _playerControlManager;

        private void Start()
        {
            _playerControlManager = PlayerControlManager.Instance;
            _playerProfileDropdown.onValueChanged.AddListener(UpdatePlayerControlsProfile);
            //BaseButton.onClick.AddListener(() => UpdateCharacter(Item));
        }

        public override void Init(Character character, Callback<Character> callback)
        {
            base.Init(character, callback);
            
            var playerProfiles = _playerControlManager.PlayerControlsProfiles;
            _playerProfileDropdown.AddOptions(playerProfiles.Select(x => new Dropdown.OptionData(x.ProfileName)).ToList());
        }

        private void UpdatePlayerControlsProfile(int index)
        {
            _playerControlsProfile = _playerControlManager.GetPlayerControlsProfile(index);
        }

        private void UpdateCharacter(Character character)
        {
            _characterImage.sprite = character.CharacterPortrait;
            Text.text = character.CharacterInfo.CharacterName;
            
        }

        private void SetReady()
        {
            var character = CharacterManager.Instance.GetCharacter(Text.text);
            var gamePlayer = new GamePlayer(character, _playerControlsProfile);
            GameManager.Instance.AddPlayer(gamePlayer, _selectingForPlayer);
            Debug.LogFormat("Player {0}, with {1} is ready", gamePlayer.PlayerControlsProfile, gamePlayer.Character);
        }

        public override void OnDisable()
        {
            PoolManager.Instance.ReturnToPool(this);
        }
    }
}