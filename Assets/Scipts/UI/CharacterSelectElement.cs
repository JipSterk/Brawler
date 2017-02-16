using System.Linq;
using Brawler.Characters;
using Brawler.CustomInput;
using Brawler.GameManagement;
using Brawler.GameSettings;
using Brawler.Music;
using UnityEngine;
using UnityEngine.UI;

namespace Brawler.UI
{
    public class CharacterSelectElement : BaseUiElement<UiJoyStick>
    {
        [SerializeField] private SelectingForPlayer _selectingForPlayer;
        [SerializeField] private Text _characterName;
        [SerializeField] private Image _characterImage;
        [SerializeField] private Dropdown _playerProfileDropdown;
        
        private PlayerControlsProfile _playerControlsProfile;
        private int _index;
        
        public override void Init(UiJoyStick uiJoyStick, CallBack<UiJoyStick> callBack)
        {
            base.Init(uiJoyStick, callBack);
            RemoveAllListeners();
        
            _playerControlsProfile = uiJoyStick.PlayerControlsProfile;
            
            var playerProfiles = PlayerControlManager.Instance.PlayerControlsProfiles;
            var options = playerProfiles.Select(profile => new Dropdown.OptionData(profile.ProfileName)).ToList();
            _playerProfileDropdown.AddOptions(options);
            _playerProfileDropdown.value = (int) uiJoyStick.UiJoyStickIndex;

            _playerProfileDropdown.onValueChanged.AddListener(UpdatePlayerControlsProfile);
        }
        
        private void UpdatePlayerControlsProfile(int index)
        {
            _playerControlsProfile = PlayerControlManager.Instance.GetPlayerControlsProfile(index);
        }

        private void UpdateCharacter(Character character)
        {
            _characterImage.sprite = character.CharacterPortrait;
            _characterName.text = character.CharacterInfo.CharacterName;
            MusicManager.Instance.PlayClip(character.CharacterClips.SelectSound);

            SetReady();
        }

        private void SetReady()
        {
            var character = CharacterManager.Instance.GetCharacter(_characterName.text);
            var gamePlayer = new GamePlayer(character, _playerControlsProfile);
            GameManager.Instance.AddPlayer(gamePlayer, _selectingForPlayer);
            Debug.LogFormat("Player {0}, with {1} is ready", gamePlayer.PlayerControlsProfile, gamePlayer.Character);
        }
    }
}