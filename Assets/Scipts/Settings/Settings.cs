using System;
using Brawler.Characters;
using Brawler.UI;
using UnityEngine;

namespace Brawler.GameSettings
{
    [Serializable]
    public struct Settings
    {
        public Settings(float backGroundVolume, float menuVolume, float soundEffectsVolume, CharacterOutline characterOutline, DamageDisplayLayout damageDisplayLayout, GraphicsSettings graphicsSettings)
        {
            _backGroundVolume = backGroundVolume;
            _menuVolume = menuVolume;
            _soundEffectsVolume = soundEffectsVolume;
            _characterOutline = characterOutline;
            _damageDisplayLayout = damageDisplayLayout;
            _graphicsSettings = graphicsSettings;
        }

        public float BackGroundVolume { get { return _backGroundVolume; } }
        public float MenuVolume { get { return _menuVolume; } }
        public float SoundEffectsVolume { get { return _soundEffectsVolume; } }
        public CharacterOutline CharacterOutline { get { return _characterOutline; } }
        public DamageDisplayLayout DamageDisplayLayout { get { return _damageDisplayLayout; } }
        public GraphicsSettings GraphicsSettings { get { return _graphicsSettings; } }

        [SerializeField] private float _backGroundVolume;
        [SerializeField] private float _menuVolume;
        [SerializeField] private float _soundEffectsVolume;
        [SerializeField] private CharacterOutline _characterOutline;
        [SerializeField] private DamageDisplayLayout _damageDisplayLayout;
        [SerializeField] private GraphicsSettings _graphicsSettings;
    }
}