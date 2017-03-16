using System;

namespace Brawler.CustomInput
{
    [Serializable]
    public struct JoyStickButton
    {
        public JoyStickButton(JoyStickButtons joyStickButtons, string buttonName)
        {
            _joyStickButtons = joyStickButtons;
            _buttonName = buttonName;
        }

        public JoyStickButtons JoyStickButtons { get { return _joyStickButtons; } }
        public string ButtonName { get { return _buttonName; } }
        
        private JoyStickButtons _joyStickButtons;
        private string _buttonName;
    }
}