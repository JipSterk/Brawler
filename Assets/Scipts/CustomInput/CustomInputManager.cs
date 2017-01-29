using UnityEngine;

namespace Brawler.CustomInput
{
    public static class CustomInputManager
    {
        public static bool GetButton(JoyStickButton button)
        {
            return Input.GetKey((KeyCode) button.JoyStickButtons);
        }

        public static bool GetButtonUp(JoyStickButton button)
        {
            return Input.GetKeyUp((KeyCode) button.JoyStickButtons);
        }

        public static bool GetButtonDown(JoyStickButton button)
        {
            return Input.GetKeyDown((KeyCode) button.JoyStickButtons);
        }

        public static float GetAxis(JoyStickAxis joyStickAxis)
        {
            return Input.GetAxis(joyStickAxis.JoyStickAxises.ToString());
        }

        public static float GetAxisRaw(JoyStickAxis joyStickAxis)
        {
            return Input.GetAxisRaw(joyStickAxis.JoyStickAxises.ToString());
        }
    }
}