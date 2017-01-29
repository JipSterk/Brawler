using System;
using System.Linq;
using Brawler.Characters;
using Brawler.CustomInput;
using Brawler.GameSettings;
using Brawler.Music;
using UnityEngine;
using UnityEngine.UI;

namespace Brawler.UI
{
    public class CharacterSelectElement : BaseUiElement<UiJoyStick>
    {
        [SerializeField] private CharacterSelectElementState _characterSelectElementState;
        [SerializeField] private Text _characterName;
        [SerializeField] private Image _characterImage;
        [SerializeField] private Dropdown _playerProfileDropdown;
        
        private PlayerControlsProfile _playerControlsProfile;
        private int _index;
        
        public override void Init(UiJoyStick uiJoyStick, CallBack<UiJoyStick> callBack)
        {
            base.Init(uiJoyStick, callBack);
            RemoveAllListeners();
            AddListener(() => UpdateUi(Get()));

            _playerControlsProfile = uiJoyStick.PlayerControlsProfile;
            
            var playerProfiles = PlayerControlManager.Instance.PlayerControlsProfiles;
            var options = playerProfiles.Select(profile => new Dropdown.OptionData(profile.ProfileName)).ToList();
            _playerProfileDropdown.AddOptions(options);
            _playerProfileDropdown.value = (int) uiJoyStick.UiJoyStickIndex;

            _playerProfileDropdown.onValueChanged.AddListener(UpdatePlayerControlsProfile);
        }

        private CharacterSelectElementState Get()
        {
            switch (_index)
            {
                case 0:
                    return CharacterSelectElementState.None;
                case 1:
                    return CharacterSelectElementState.Player;
                case 2:
                    return CharacterSelectElementState.Cpu;
                default:
                    throw new IndexOutOfRangeException();
            }
        }

        private void UpdateUi(CharacterSelectElementState characterSelectElementState)
        {
            switch (characterSelectElementState)
            {
                case CharacterSelectElementState.None:
                    break;
                case CharacterSelectElementState.Player:
                    SetText(_t.UiJoyStickIndex.ToString());
                    break;
                case CharacterSelectElementState.Cpu:
                    SetText("Cpu");
                    break;
                default:
                    throw new ArgumentOutOfRangeException("characterSelectElementState", characterSelectElementState, null);
            }
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
            GameManager.Instance.AddPlayer(gamePlayer);
            Debug.LogFormat("Player {0}, with {1} is ready", gamePlayer.PlayerControlsProfile, gamePlayer.Character);
        }
    }
}