using Steamworks;
using UnityEngine;

namespace Brawler.Networking.Character
{
    public class NetworkCharacterSetup : MonoBehaviour
    {
        [SerializeField] private Behaviour[] _behaviours;

        private Callback<ThreadPriority> x;

        private void Start()
        {
            foreach (var behaviour in _behaviours)
                behaviour.enabled = true;
        }
    }
}