using System;
using System.Linq;
using UnityEngine;

[Serializable]
public struct Animations
{
    public string AnimationName { get { return _animationName; } }
    public FrameInfo[] FrameInfos { get { return _frameInfos; } }

    [SerializeField] private string _animationName;
    [SerializeField] private FrameInfo[] _frameInfos;
}

[Serializable]
public struct FrameInfo
{
    public Hitbox[] HitBoxes { get { return _hitBoxes; } }
    public HurtBox[] HurtBoxes { get { return _hurtBoxes; } }

    [SerializeField] private Hitbox[] _hitBoxes;
    [SerializeField] private HurtBox[] _hurtBoxes;
}

[Serializable]
public struct HurtBox
{
    public Rect HurtBoxdimentions { get { return _hurtBoxDimentions; } }

    [SerializeField] private Rect _hurtBoxDimentions;
}

[Serializable]
public struct Hitbox
{
    public float Damage { get { return _damage; } }
    public Rect HitBoxDimentions { get { return _hitBoxDimentions; } }

    [SerializeField] [Range(0f, 10f)] private float _damage;
    [SerializeField] private Rect _hitBoxDimentions;
}

public class Test : MonoBehaviour
{
    [SerializeField] private Animations[] _animations;

    private Animations _currentAnimation;
    private SpriteRenderer _debugHurtBox;
    private SpriteRenderer _debugHitBox;
    private Color _hitBoxColor = Color.green;
    private Color _hurtBoxColor = Color.red;
    private int _currentAnimationFrame;

    private void Start()
    {
        _debugHurtBox = new GameObject("HurtBox").AddComponent<SpriteRenderer>();
        _debugHurtBox.transform.SetParent(transform);
        _debugHurtBox.sprite = CreateBoxSprite();
        _debugHurtBox.color = Color.clear;

        _debugHitBox = new GameObject("HitBox").AddComponent<SpriteRenderer>();
        _debugHitBox.transform.SetParent(transform);
        _debugHitBox.sprite = CreateBoxSprite();
        _debugHitBox.color = Color.clear;

        SetAnimation("idle");
    }

    private Sprite CreateBoxSprite()
    {
        var texture2D = new Texture2D(100, 100);
        texture2D.SetPixel(0, 0, Color.white);
        texture2D.Apply();

        return Sprite.Create(texture2D, new Rect(0, 0, 100, 100), new Vector2(0.5f, 0.5f));
    }

    private void Update()
    {
        DrawBoxes();
    }

    public void SetAnimation(string animationName)
    {
        _currentAnimation = _animations.First(x => x.AnimationName == animationName);
    }

    public void SetAnimationFrame(int currentAnimationFrame)
    {
        _currentAnimationFrame = currentAnimationFrame;
    }

    private void DrawBoxes()
    {
        var position = new Vector2(transform.position.x, transform.position.y);

        if (_currentAnimation.FrameInfos[_currentAnimationFrame].HurtBoxes.Length != 0)
        {
            foreach (var hurtBox in _currentAnimation.FrameInfos[_currentAnimationFrame].HurtBoxes)
            {
                var rect = new Rect(hurtBox.HurtBoxdimentions.position + position, hurtBox.HurtBoxdimentions.size);
                _debugHurtBox.transform.position = new Vector2(rect.x, rect.y);
                _debugHurtBox.transform.localScale = new Vector2(rect.width, rect.height);
                _debugHurtBox.color = _hurtBoxColor;
            }
        }
        else
            _debugHurtBox.color = Color.clear;
        
        if (_currentAnimation.FrameInfos[_currentAnimationFrame].HitBoxes.Length != 0)
        {
            foreach (var hitbox in _currentAnimation.FrameInfos[_currentAnimationFrame].HitBoxes)
            {
                var rect = new Rect(hitbox.HitBoxDimentions.position + position, hitbox.HitBoxDimentions.size);
                _debugHitBox.transform.position = new Vector2(rect.x, rect.y);
                _debugHitBox.transform.localScale = new Vector2(rect.width, rect.height);
                _debugHitBox.color = _hurtBoxColor;
            }
        }
        else
            _debugHitBox.color = Color.clear;
    }
}