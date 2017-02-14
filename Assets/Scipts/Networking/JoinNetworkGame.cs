using System.Collections.Generic;
using Brawler.GameSettings;
using Brawler.Networking.Extentions;
using Brawler.UI;
using Steamworks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.UI;

namespace Brawler.Networking
{
    public class JoinNetworkGame : MonoBehaviour
    {
        [SerializeField] private int _amountOfMatchesToShow = 20;
        [SerializeField] private int _margin;
        [SerializeField] private string _matchNameFilter = string.Empty;
        [SerializeField] private bool _matchPrivateFilter = false;
        [SerializeField] private Text _statusText;
        private List<CSteamID> _lobbyIds = new List<CSteamID>();

        private void Start()
        {
            
        }

        private void RefreshRoomList()
        {
            var requestLobbyList = SteamMatchmaking.RequestLobbyList();
        }

        private void OnMatchList(LobbyMatchList_t lobbyMatchList)
        {
            for (var i = 0; i < lobbyMatchList.m_nLobbiesMatching; i++)
            {
                var lobbyId = SteamMatchmaking.GetLobbyByIndex(i);
                _lobbyIds.Add(lobbyId);
                var lobbyData = SteamMatchmaking.RequestLobbyData(lobbyId);
            }
        }

        private void JoinRoom(MatchInfoSnapshot matchInfoSnapshot, PlayerOnlineInfo playerOnlineInfo)
        {
            
        }
    }
}