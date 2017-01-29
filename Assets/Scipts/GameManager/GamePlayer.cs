using System;
using Brawler.Characters;
using Brawler.CustomInput;

namespace Brawler.GameSettings
{
    [Serializable]
    public struct GamePlayer
    {
        public GamePlayer(Character character, PlayerControlsProfile playerControlsProfile)
        {
            _character = character;
            _playerControlsProfile = playerControlsProfile;
        }

        public Character Character { get { return _character; } }
        public PlayerControlsProfile PlayerControlsProfile { get { return _playerControlsProfile; } }

        private Character _character;
        private PlayerControlsProfile _playerControlsProfile;
    }
}