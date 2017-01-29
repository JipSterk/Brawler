using System;

namespace Brawler.CustomInput
{
    [Serializable]
    public struct JoyStickButton
    {
        public JoyStickButton(JoyStickButtons joyStickButtons, ActionType actionType, string buttonName)
        {
            _joyStickButtons = joyStickButtons;
            _actionType = actionType;
            _buttonName = buttonName;
        }

        public JoyStickButtons JoyStickButtons { get { return _joyStickButtons; } }
        public ActionType ActionType { get { return _actionType; } }
        public string ButtonName { get { return _buttonName; } }
        
        private JoyStickButtons _joyStickButtons;
        private ActionType _actionType;
        private string _buttonName;
    }
}