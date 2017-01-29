using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Brawler.SaveLoad;
using Brawler.UI;

namespace Brawler.CustomInput
{
    public class PlayerControlManager : MonoBehaviour
    {
        public List<PlayerControlsProfile> PlayerControlsProfiles { get { return _playerControlsProfiles; } }
        public List<UiJoyStick> UiJoySticks { get { return _uiJoySticks; } }
        public static PlayerControlManager Instance { get{ return _instance; } }

        [SerializeField] private UiJoyStick _uiJoyStickPrefab;

        private static PlayerControlManager _instance;
        private List<PlayerControlsProfile> _playerControlsProfiles = new List<PlayerControlsProfile>();
        private List<UiJoyStick> _uiJoySticks = new List<UiJoyStick>();
        private string[] _buttonNames;
        private JoyStickButtons[,] _joyStickButtons;
        private JoyStickAxises[,] _joyStickAxises;
        private SaveLoadManager _saveLoadManager;

        private void Awake()
        {
            if (_instance)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            _saveLoadManager = SaveLoadManager.Instance;

            _saveLoadManager.WhenSaveFileExist += LoadPlayerProfiles;
            SetupJoySticks();
            Init();
        }

        private void Init()
        {
            var connectedJoysticks = Input.GetJoystickNames().Where(x => !string.IsNullOrEmpty(x)).ToArray();
            var parent = InterfaceManager.Instance.InterfaceCanvasTransform;

            for (var i = 0; i < connectedJoysticks.Length; i++)
            {
                var playerControlsProfile = CreatePlayerControlsProfile((JoyStickIndex)i, null);
                var uiJoyStick = Instantiate(_uiJoyStickPrefab, parent);
                uiJoyStick.Init(playerControlsProfile);
                _uiJoySticks.Add(uiJoyStick);
            }
        }

        private void SetupJoySticks()
        {
            _buttonNames = new[]
            {
                "A",
                "B",
                "X",
                "Y",
                "LB",
                "RB",
                "Start",
                "Back"
            };

            _joyStickAxises = new[,]
            {
                {JoyStickAxises.Joystick1LeftHorizontal, JoyStickAxises.Joystick2LeftHorizontal,JoyStickAxises.Joystick3LeftHorizontal, JoyStickAxises.Joystick4LeftHorizontal},
                {JoyStickAxises.Joystick1LeftVertical, JoyStickAxises.Joystick2LeftVertical,JoyStickAxises.Joystick3LeftVertical, JoyStickAxises.Joystick4LeftVertical},
                {JoyStickAxises.Joystick1RightHorizontal, JoyStickAxises.Joystick2RightHorizontal,JoyStickAxises.Joystick3RightHorizontal, JoyStickAxises.Joystick4RightHorizontal},
                {JoyStickAxises.Joystick1RightVertical, JoyStickAxises.Joystick2RightVertical,JoyStickAxises.Joystick3RightVertical, JoyStickAxises.Joystick4RightVertical},
                {JoyStickAxises.Joystick1LeftTrigger, JoyStickAxises.Joystick2LeftTrigger,JoyStickAxises.Joystick3LeftTrigger, JoyStickAxises.Joystick4LeftTrigger},
                {JoyStickAxises.Joystick1RightTrigger, JoyStickAxises.Joystick2RightTrigger,JoyStickAxises.Joystick3RightTrigger, JoyStickAxises.Joystick4RightTrigger},
                {JoyStickAxises.Joystick1DpadHorizontal, JoyStickAxises.Joystick2DpadHorizontal,JoyStickAxises.Joystick3DpadHorizontal, JoyStickAxises.Joystick4DpadHorizontal},
                {JoyStickAxises.Joystick1DpadVertical, JoyStickAxises.Joystick2DpadVertical,JoyStickAxises.Joystick3DpadVertical, JoyStickAxises.Joystick4DpadVertical}
            };

            _joyStickButtons = new[,]
            {
                {JoyStickButtons.Joystick1A, JoyStickButtons.Joystick2A, JoyStickButtons.Joystick3A, JoyStickButtons.Joystick4A},
                {JoyStickButtons.Joystick1B, JoyStickButtons.Joystick2B, JoyStickButtons.Joystick3B, JoyStickButtons.Joystick4B},
                {JoyStickButtons.Joystick1X, JoyStickButtons.Joystick2X, JoyStickButtons.Joystick3X, JoyStickButtons.Joystick4X},
                {JoyStickButtons.Joystick1Y, JoyStickButtons.Joystick2Y, JoyStickButtons.Joystick3Y, JoyStickButtons.Joystick4Y},
                {JoyStickButtons.Joystick1Lb, JoyStickButtons.Joystick2Lb, JoyStickButtons.Joystick3Lb,JoyStickButtons.Joystick4Lb},
                {JoyStickButtons.Joystick1Rb, JoyStickButtons.Joystick2Rb, JoyStickButtons.Joystick3Rb,JoyStickButtons.Joystick4Rb},
                {JoyStickButtons.Joystick1Start, JoyStickButtons.Joystick2Start, JoyStickButtons.Joystick3Start,JoyStickButtons.Joystick4Start},
                {JoyStickButtons.Joystick1Back, JoyStickButtons.Joystick2Back, JoyStickButtons.Joystick3Back,JoyStickButtons.Joystick4Back}
            };
        }

        public JoyStickButton[] GetJoyStickButtons(JoyStickIndex joyStickIndex)
        {
            var index = (int) joyStickIndex;
            var buttons = new JoyStickButton[8];
            
            for (var i = 0; i < buttons.Length; i++)
                buttons[i] = new JoyStickButton(_joyStickButtons[i, index], (ActionType)i,_buttonNames[i]);

            return buttons;
        }

        public JoyStickAxis[] GetJoyStickAxises(JoyStickIndex joyStickIndex)
        {
            var index = (int) joyStickIndex;
            var axises = new JoyStickAxis[8];

            for (var i = 0; i < axises.Length; i++)
                axises[i] = new JoyStickAxis(_joyStickAxises[i, index]);
            
            return axises;
        }

        public PlayerControlsProfile CreatePlayerControlsProfile(JoyStickIndex joyStickIndex, string profileName)
        {
            var format = string.Format("{0} {1}", joyStickIndex, profileName);
            var playerControlsProfile = new PlayerControlsProfile(format, joyStickIndex);
            _playerControlsProfiles.Add(playerControlsProfile);

            return playerControlsProfile;
        }
        
        public PlayerControlsProfile GetPlayerControlsProfile(string profileName)
        {
            return _playerControlsProfiles.First(x => x.ProfileName == profileName);
        }

        public PlayerControlsProfile GetPlayerControlsProfile(int index)
        {
            return _playerControlsProfiles[index];
        }
        
        private void LoadPlayerProfiles(SaveData saveData)
        {
            _playerControlsProfiles = saveData.PlayerControlsProfiles;
        }

        public bool DoesProfileNameExist(string profileName)
        {
            return _playerControlsProfiles.Any(x => x.ProfileName == profileName);
        }

        public JoyStickIndex GetJoyStickIndex()
        {
            throw new NotImplementedException();
        }
    }
}