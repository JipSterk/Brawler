using System.Collections.Generic;

namespace Brawler.GameSettings
{
    public static class MenuStateExtension
    {
        private static readonly Dictionary<MenuState, int> Table = new Dictionary<MenuState, int>
        {
            {MenuState.TitleScreen, 0},
            {MenuState.Menu, 1},
            {MenuState.OnlineMultiPlayer, 2},
            {MenuState.CharacterSelection, 3},
            {MenuState.LevelSelection, 4},
            {MenuState.MatchRules, 4},
            {MenuState.OfflineMultiPlayer, 2},
            {MenuState.InGamePauseMenu, 0},
            {MenuState.PlayerInput, 2},
            {MenuState.NewPlayerInputProfile, 3},
            {MenuState.SoundSettings, 2},
            {MenuState.FighterOutline, 2},
            {MenuState.DamageDisplay, 2},
            {MenuState.Quit, 2}
        };

        public static bool IsBiggerThen(this MenuState lhs, MenuState rhs)
        {
            return Table[lhs] > Table[rhs];
        }

        public static bool IsSmallerThen(this MenuState lhs, MenuState rhs)
        {
            return Table[lhs] < Table[rhs];
        }
    }
}