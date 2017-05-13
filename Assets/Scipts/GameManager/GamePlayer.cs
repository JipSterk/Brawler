using System;
using Brawler.Characters;
using Rewired;

namespace Brawler.GameSettings
{
    [Serializable]
    public struct GamePlayer
    {
        public GamePlayer(Character character, ControllerMap controllerMap)
        {
            _character = character;
            _controllerMap = controllerMap;
        }

        public Character Character { get { return _character; } }
        public ControllerMap ControllerMap { get { return _controllerMap; } }

        private Character _character;
        private ControllerMap _controllerMap;
    }
}