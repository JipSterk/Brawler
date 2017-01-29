using System;
using System.Collections.Generic;
using System.Linq;

namespace Brawler.CustomInput
{
    [Serializable]
    public struct PlayerControlsProfile
    {
        public PlayerControlsProfile(string profileName, JoyStickIndex joyStickIndex)
        {
            _joyStickIndex = joyStickIndex;
            _profileName = profileName;
            _joyStickButtons = new Dictionary<string, JoyStickButton>();

            var buttons = PlayerControlManager.Instance.GetJoyStickButtons(joyStickIndex);
            var axises = PlayerControlManager.Instance.GetJoyStickAxises(joyStickIndex);

            foreach (var joyStickButton in buttons)
                _joyStickButtons.Add(joyStickButton.ButtonName, joyStickButton);

            _a = buttons[0];
            _b = buttons[1];
            _x = buttons[2];
            _y = buttons[3];
            _lb = buttons[4];
            _rb = buttons[5];
            _start = buttons[6];
            _back = buttons[7];
            _joyStickLeftHorizontalAxis = axises[0];
            _joyStickLeftVerticalAxis = axises[1];
            _joyStickRightHorizontalAxis = axises[2];
            _joyStickRightVerticalAxis = axises[3];
            _leftTrigger = axises[4];
            _rightTrigger = axises[5];
            _dPadHorizontal = axises[6];
            _dPadVertical = axises[7];
         }

        public void RemapButton(string buttonName, JoyStickButtons joyStickButtons, ActionType actionType)
        {
            _joyStickButtons[buttonName] = new JoyStickButton(joyStickButtons, actionType, buttonName);
        }

        public string ProfileName { get { return _profileName; } }
        public JoyStickIndex JoyStickIndex { get { return _joyStickIndex; } }
        public JoyStickButton A { get { return _a; } }
        public JoyStickButton B { get { return _b; } }
        public JoyStickButton X { get { return _x; } }
        public JoyStickButton Y { get { return _y; } }
        public JoyStickButton Lb { get { return _lb; } }
        public JoyStickButton Rb { get { return _rb; } }
        public JoyStickButton Start { get { return _start; } }
        public JoyStickButton Back { get { return _back; } }
        public JoyStickAxis JoyStickLeftHorizontalAxis { get { return _joyStickLeftHorizontalAxis; } }
        public JoyStickAxis JoyStickLeftVerticalAxis { get { return _joyStickLeftVerticalAxis; } }
        public JoyStickAxis JoyStickRightHorizontalAxis { get { return _joyStickRightHorizontalAxis; } }
        public JoyStickAxis JoyStickRightVerticalAxis { get { return _joyStickRightVerticalAxis; } }
        public JoyStickAxis LeftTrigger { get { return _leftTrigger; } }
        public JoyStickAxis RightTrigger { get { return _rightTrigger; } }
        public JoyStickAxis DPadHorizontal { get { return _dPadHorizontal; } }
        public JoyStickAxis DdPadVertical { get { return _dPadVertical; } }

        private Dictionary<string, JoyStickButton> _joyStickButtons;
        private string _profileName;
        private JoyStickIndex _joyStickIndex;
        private JoyStickButton _a;
        private JoyStickButton _b;
        private JoyStickButton _x;
        private JoyStickButton _y;
        private JoyStickButton _lb;
        private JoyStickButton _rb;
        private JoyStickButton _start;
        private JoyStickButton _back;
        private JoyStickAxis _joyStickLeftHorizontalAxis;
        private JoyStickAxis _joyStickLeftVerticalAxis;
        private JoyStickAxis _joyStickRightHorizontalAxis;
        private JoyStickAxis _joyStickRightVerticalAxis;
        private JoyStickAxis _leftTrigger;
        private JoyStickAxis _rightTrigger;
        private JoyStickAxis _dPadHorizontal;
        private JoyStickAxis _dPadVertical;
    }
}