using System;
using Brawler.Characters;
using Rewired;

namespace Brawler.GameSettings
{
    [Serializable]
    public struct GamePlayer
    {
        public GamePlayer(Character character, Player player)
        {
            _character = character;
            _player = player;
        }

        public Character Character { get { return _character; } }
        public Player Player { get { return _player; } }

        private readonly Character _character;
        private readonly Player _player;
    }
}