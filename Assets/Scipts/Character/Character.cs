﻿using UnityEngine;
using System.Collections;
using Brawler.CustomInput;
using Brawler.GameSettings;
using Brawler.LevelManagment;

namespace Brawler.Characters
{
    public class Character : MonoBehaviour
    {
        public Sprite CharacterPortrait { get { return _characterPortrait; } }
        public CharacterInfo CharacterInfo { get { return _characterInfo; } }
        public CharacterStats CharacterStats { get { return _characterStats; } }
        public CharacterClips CharacterClips { get { return _characterClips; } }

        public event Callback<float> OnCharacterDamage;

        [SerializeField] private Sprite _characterPortrait;
        [SerializeField] private TextMesh _textMesh;
        [SerializeField] private CharacterInfo _characterInfo;
        [SerializeField] private CharacterStats _characterStats;
        [SerializeField] private CharacterClips _characterClips;
        [SerializeField] private CharacterAttacks _characterAttacks;
        [SerializeField] [Range(0, 1)] private float _deadZone = 0.6f;
        [SerializeField] [Range(0, 1)] private float _leftTriggerThresHold = 0.5f;
        [SerializeField] [Range(0, 1)] private float _rightTriggerThresHold = 0.5f;

        private PlayerControlsProfile _playerControlsProfile;
        private Animator _animator;
        private AnimatorStateInfo _animatorStateInfo;
        private AnimatorTransitionInfo _animatorTransitionInfo;
        private Rigidbody _rigidbody;
        private CharacterOutline _characterOutline;
        private AttackDirection _attackDirection;
        private float _leftHorizontal;
        private float _leftVertical;
        private float _rightHorizontal;
        private float _rightVertical;
        private float _dpadHorizontal;
        private float _dpadVertical;
        private float _leftTrigger;
        private float _rightTrigger;
        private float _health;
        private bool _isNockedOut;
        
        private int _locomotionId;
        private LevelManager _levelManager;
        private GameManager _gameManager;
        
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();

            _levelManager = LevelManager.Instance;
            _gameManager = GameManager.Instance;
            _locomotionId = Animator.StringToHash("Base Layer.Locomotion");
        }

        public void Init(PlayerControlsProfile playerControlsProfile, CharacterOutline characterOutline)
        {
            _playerControlsProfile = playerControlsProfile;
            _characterOutline = characterOutline;

            _textMesh.text = _playerControlsProfile.ProfileName;
            
            transform.name = _characterInfo.CharacterName;
            _health = _characterStats.Health;
        }

        public void Update()
        {
            _leftHorizontal = CustomInputManager.GetAxis(_playerControlsProfile.JoyStickLeftHorizontalAxis);
            _leftVertical = CustomInputManager.GetAxis(_playerControlsProfile.JoyStickLeftVerticalAxis);
            _rightHorizontal = CustomInputManager.GetAxis(_playerControlsProfile.JoyStickRightHorizontalAxis);
            _rightVertical = CustomInputManager.GetAxis(_playerControlsProfile.JoyStickRightVerticalAxis);
            _dpadHorizontal = CustomInputManager.GetAxis(_playerControlsProfile.DPadHorizontal);
            _dpadVertical = CustomInputManager.GetAxis(_playerControlsProfile.DdPadVertical);
            _leftTrigger = CustomInputManager.GetAxis(_playerControlsProfile.LeftTrigger);
            _rightTrigger = CustomInputManager.GetAxis(_playerControlsProfile.RightTrigger);

            if (CustomInputManager.GetButton(_playerControlsProfile.A))
                NormalAttack();
            if (CustomInputManager.GetButton(_playerControlsProfile.B))
                SpecialAttack();
            if (CustomInputManager.GetButton(_playerControlsProfile.X))
                Jump();
            if (CustomInputManager.GetButton(_playerControlsProfile.Y))
                Jump();
            if (CustomInputManager.GetButton(_playerControlsProfile.Lb))
                Shield();
            if (CustomInputManager.GetButton(_playerControlsProfile.Rb))
                Shield();

            if (_leftTrigger > _leftTriggerThresHold)
                Grab();
            if (_rightTrigger > _rightTriggerThresHold)
                Grab();

            //_animatorStateInfo = _animator.GetCurrentAnimatorStateInfo(0);
            //_animatorTransitionInfo = _animator.GetAnimatorTransitionInfo(0);

            MoveCharacter(new Vector2(_leftHorizontal, _leftVertical));
        }
        
        private void MoveCharacter(Vector2 stickInput)
        {
            if (stickInput.magnitude < _deadZone)
                stickInput = Vector2.zero;
            else
                stickInput = stickInput.normalized * ((stickInput.magnitude - _deadZone) / (1 - _deadZone)) * _characterStats.WalkSpeed;

            _rigidbody.velocity = new Vector3(stickInput.x, _rigidbody.velocity.y);
        }
        
        public void TakeDamage(float amount)
        {
            if (!_isNockedOut)
                return;

            _health -= amount;

            if (OnCharacterDamage != null)
                OnCharacterDamage(_health);
        }
        
        public void SetDefaults(Vector3 startPosition)
        {
            _health = 0;
            _isNockedOut = true;
            transform.position = startPosition;
        }

        private bool IsInJump()
        {
            return IsInIdleJump() || IsInLocomotionJump();
        }

        private bool IsCrouch()
        {
            return _animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Crouch");
        }

        private bool IsSprint()
        {
            return _animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Sprint");
        }

        private bool IsInIdleJump()
        {
            return _animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.IdleJump");
        }

        private bool IsInLocomotionJump()
        {
            return _animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.LocomotionJump");
        }

        private bool IsInLocomotion()
        {
            return _animatorStateInfo.fullPathHash == _locomotionId;
        }
        
        private void NormalAttack()
        {
            Debug.Log("Normal Attack");
        }

        private void SpecialAttack()
        {
            Debug.Log("Special Attack");
        }

        public void Grab()
        {
            Debug.Log("Grab");
        }

        public void Shield()
        {
            Debug.Log("Shield");
        }

        public void Jump()
        {
            Debug.Log("Jump");
        }

        public void Taunt()
        {
            Debug.Log("Taunt");
        }
    }
}