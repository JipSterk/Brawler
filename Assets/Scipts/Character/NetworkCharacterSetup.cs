using UnityEngine;

namespace Brawler.Networking.Character
{
    public class NetworkCharacterSetup : MonoBehaviour
    {
        [SerializeField] private Behaviour[] _behaviours;

        private void Start()
        {
            if(!enabled)
                return;

            foreach (var behaviour in _behaviours)
                behaviour.enabled = true;
        }
    }
}