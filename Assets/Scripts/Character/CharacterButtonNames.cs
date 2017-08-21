using System;
using UnityEngine;

namespace Brawler.Characters
{
    [Serializable]
    public class CharacterButtonNames
    {
        public string LightPunch { get { return _lightPunch; } }
        public string MediumPunch { get { return _mediumPunch; } }
        public string HardPunch { get { return _hardPunch; } }
        public string LightKick { get { return _lightKick; } }
        public string MediumKick { get { return _mediumKick; } }
        public string HardKick { get { return _hardKick; } }

        [SerializeField] private string _lightPunch = "Light Punch";
        [SerializeField] private string _mediumPunch = "Medium Punch";
        [SerializeField] private string _hardPunch = "Hard Punch";
        [SerializeField] private string _lightKick = "Light Kick";
        [SerializeField] private string _mediumKick = "Medium Kick";
        [SerializeField] private string _hardKick = "Medium Kick";
    }
}