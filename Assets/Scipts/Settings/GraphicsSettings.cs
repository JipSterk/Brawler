using System;
using UnityEngine;

namespace Brawler.GameSettings
{
    [Serializable]
    public struct GraphicsSettings
    {
        public GraphicsSettings(Resolution resolution, int qualitySettings)
        {
            _resolution = resolution;
            _qualitySettings = qualitySettings;
        }

        public Resolution Resolution { get { return _resolution; } }
        public int QualitySettings { get { return _qualitySettings; } }

        private Resolution _resolution;
        private int _qualitySettings;
    }
}