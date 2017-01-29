using System;
using System.Collections.Generic;
using Brawler.CustomInput;
using Brawler.GameSettings;
using Brawler.LevelManagment;
using Brawler.Characters;
using Brawler.Networking;

namespace Brawler.SaveLoad
{
    [Serializable]
    public struct SaveData
    {
        public SaveData(List<PlayerControlsProfile> playerControlsProfiles, List<CharacterInfo> characterInfos, List<LevelData> levelsData, PlayerOnlineInfo playerOnlineInfo,Settings settings)
        {
            _playerControlsProfiles = playerControlsProfiles;
            _characterInfos = characterInfos;
            _levelsData = levelsData;
            _playerOnlineInfo = playerOnlineInfo;
            _settings = settings;
        }

        public List<PlayerControlsProfile> PlayerControlsProfiles { get { return _playerControlsProfiles; } }
        public List<CharacterInfo> CharacterInfos { get { return _characterInfos; } }
        public List<LevelData> LevelsData { get { return _levelsData; } }
        public PlayerOnlineInfo PlayerOnlineInfo { get { return _playerOnlineInfo; } }
        public Settings Settings { get { return _settings; } }

        private List<PlayerControlsProfile> _playerControlsProfiles;
        private List<CharacterInfo> _characterInfos;
        private List<LevelData> _levelsData;
        private PlayerOnlineInfo _playerOnlineInfo;
        private Settings _settings;
    }
}