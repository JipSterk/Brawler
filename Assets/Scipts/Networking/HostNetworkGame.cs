using Brawler.GameSettings;
using Brawler.UI;
using Steamworks;
using UnityEngine;
using UnityEngine.Networking;

namespace Brawler.Networking
{
    public class HostNetworkGame : MonoBehaviour
    {
        private int _matchSize = 2;
        private string _matchName;
        private string _matchPassword;
        
        private void Start()
        {
            
        }
        
        private void CreateLobby(ELobbyType eLobbyType)
        {
            //SteamMatchmaking.AddRequestLobbyListNearValueFilter();
            var createLobby = SteamMatchmaking.CreateLobby(eLobbyType, _matchSize);
            
        }
    }
}