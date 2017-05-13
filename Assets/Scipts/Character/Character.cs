using UnityEngine;
using Brawler.GameSettings;
using Brawler.LevelManagement;
using Rewired;

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
        [SerializeField] private CharacterInfo _characterInfo;
        [SerializeField] private CharacterStats _characterStats;
        [SerializeField] private CharacterClips _characterClips;
        [SerializeField] private CharacterButtonNames _characterButtonNames;
        [SerializeField] private CharacterAttacks _characterAttacks;
        [SerializeField] [Range(0, 1)] private float _deadZone = 0.6f;
        [SerializeField] [Range(0, 1)] private float _leftTriggerThresHold = 0.5f;
        [SerializeField] [Range(0, 1)] private float _rightTriggerThresHold = 0.5f;

        private Player _player;
        private LevelManager _levelManager;
        private GameManager _gameManager;
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
        private bool _isKnockedOut;
        private int _locomotionId;
        
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();

            _levelManager = LevelManager.Instance;
            _gameManager = GameManager.Instance;
            _locomotionId = Animator.StringToHash("Base Layer.Locomotion");
        }

        public void Init(Player player, CharacterOutline characterOutline)
        {
            _player = player;
            _characterOutline = characterOutline;
            
            transform.name = _characterInfo.CharacterName;
            _health = _characterStats.Health;
        }

        public void Update()
        {
            //if (_player.GetButtonDown(_characterButtonNames.LightKick))
            //if (_player.GetButtonDown(_characterButtonNames.MediumKick))
            //if (_player.GetButtonDown(_characterButtonNames.HardKick))
            //if (_player.GetButtonDown(_characterButtonNames.LightPunch))
            //if (_player.GetButtonDown(_characterButtonNames.MediumPunch))
            //if (_player.GetButtonDown(_characterButtonNames.HardPunch))
            //_animatorStateInfo = _animator.GetCurrentAnimatorStateInfo(0);
            //_animatorTransitionInfo = _animator.GetAnimatorTransitionInfo(0);

            if (_leftTrigger > _leftTriggerThresHold)
                Grab();
            if (_rightTrigger > _rightTriggerThresHold)
                Grab();
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
            if (!_isKnockedOut)
                return;

            _health -= amount;

            if (OnCharacterDamage != null)
                OnCharacterDamage(_health);
        }
        
        public void SetDefaults(Vector3 startPosition)
        {
            _health = 0;
            _isKnockedOut = true;
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