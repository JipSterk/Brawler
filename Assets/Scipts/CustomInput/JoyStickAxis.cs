using System;

namespace Brawler.CustomInput
{
    [Serializable]
    public struct JoyStickAxis
    {
        public JoyStickAxis(JoyStickAxises joyStickAxises)
        {
            _joyStickAxises = joyStickAxises;
        }

        public JoyStickAxises JoyStickAxises { get { return _joyStickAxises; } }

        private JoyStickAxises _joyStickAxises;
    }
}