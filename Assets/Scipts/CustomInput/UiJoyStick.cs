using System.Collections.Generic;
using Brawler.UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Brawler.CustomInput
{
    public class UiJoyStick : MonoBehaviour
    {
        public UiJoyStickIndex UiJoyStickIndex { get { return _uiJoyStickIndex; } }
        public PlayerControlsProfile PlayerControlsProfile { get { return _playerControlsProfile; } }

        [SerializeField] private float _moveSpeed;
        [SerializeField] [Range(0, 1)] private float _deadZone = 0.6f;

        private UiJoyStickIndex _uiJoyStickIndex;
        private PlayerControlsProfile _playerControlsProfile;
        private int _minX;
        private int _maxX;
        private int _minY;
        private int _maxY;

        public void Init(PlayerControlsProfile playerControlsProfile)
        {
            _playerControlsProfile = playerControlsProfile;
            _uiJoyStickIndex = (UiJoyStickIndex)_playerControlsProfile.JoyStickIndex;
            transform.name = playerControlsProfile.ProfileName;

            _maxY = Screen.height;
            _maxX = Screen.width;

            transform.position = new Vector3(_maxX / 2, _maxY / 2);
        }
        
        private void Update()
        {
            var horizontal = CustomInputManager.GetAxis(_playerControlsProfile.JoyStickLeftHorizontalAxis);
            var vertical = CustomInputManager.GetAxis(_playerControlsProfile.JoyStickLeftVerticalAxis);

            MoveCursor(new Vector2(horizontal, vertical));

            if (CustomInputManager.GetButtonDown(_playerControlsProfile.A))
                OnPointerClick();

            if(Input.GetKey(KeyCode.Q))
                _playerControlsProfile.RemapButton("LB",JoyStickButtons.Joystick1X, ActionType.Grab);
        }

        public void OnPointerClick()
        {
            var pointerEventData = new PointerEventData(EventSystem.current) { position = transform.position };

            var raycastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointerEventData, raycastResults);

            foreach (var raycastResult in raycastResults)
            {
                if(raycastResult.gameObject.GetComponent<IPointerClickHandler>() != null)
                    raycastResult.gameObject.GetComponent<IPointerClickHandler>().OnPointerClick(pointerEventData);
            }
        }

        private void MoveCursor(Vector2 stickInput)
        {
            if (stickInput.magnitude < _deadZone)
                stickInput = Vector2.zero;
            else
                stickInput = stickInput.normalized * ((stickInput.magnitude - _deadZone) / (1 - _deadZone));

            transform.position += new Vector3(stickInput.x , stickInput.y)* _moveSpeed;
        }
    }
}