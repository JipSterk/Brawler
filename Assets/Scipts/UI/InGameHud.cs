using System.Collections.Generic;
using System.Globalization;
using Brawler.GameManagement;
using Brawler.GameSettings;
using Brawler.LevelManagment;
using UnityEngine;
using UnityEngine.UI;

namespace Brawler.UI
{
    public class InGameHud : MonoBehaviour
    {
        [SerializeField] private Text _text;
        [SerializeField] private Slider _p1HealthBar;
        [SerializeField] private Slider _p2HealthBar;
        
        private GameManager _gameManager;
        private float _gameTime;

        private void Start()
        {
            _gameManager = GameManager.Instance;
            _gameManager.OnMatchStart += Init;
        }

        private void Init(GamePlayer p1GamePlayer, GamePlayer p2GamePlayer, Level level, MatchSettings matchSettings)
        {
            _gameTime = matchSettings.GameTime;
            _text.text = _gameTime.ToString(CultureInfo.InvariantCulture);

            p1GamePlayer.Character.OnCharacterDamage += UpdateP1;
            p2GamePlayer.Character.OnCharacterDamage += UpdateP2;

            _p1HealthBar.value = p1GamePlayer.Character.CharacterStats.Health;
            _p2HealthBar.value = p2GamePlayer.Character.CharacterStats.Health;
        }
        
        private void Update()
        {
            if(_gameManager.MenuState != MenuState.OfflineMultiplayer) 
                return;

            _text.text = (_gameTime -= Time.deltaTime).ToString("F0");
        }

        private void UpdateP1(float health)
        {
            _p1HealthBar.value = Mathf.Lerp(_p1HealthBar.value, health, Time.deltaTime);
        }

        private void UpdateP2(float health)
        {
            _p2HealthBar.value = Mathf.Lerp(_p2HealthBar.value, health, Time.deltaTime);
        }
    }
}