using System.Collections.Generic;
using Brawler.GameSettings;
using Brawler.Networking.Extentions;
using Brawler.UI;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.UI;

namespace Brawler.Networking
{
    //public class JoinNetworkGame : MonoBehaviour
    //{
    //    [SerializeField] private int _amountOfMatchesToShow = 20;
    //    [SerializeField] private int _margin;
    //    [SerializeField] private string _matchNameFilter = string.Empty;
    //    [SerializeField] private bool _matchPrivateFilter = false;
    //    [SerializeField] private Text _statusText;
        
    //    private NetworkManager _networkManager;

    //    private void Start()
    //    {
    //        _networkManager = NetworkManager.singleton;
    //        RefreshRoomList();
    //        InterfaceManager.instance.RefreshMatchesButton.onClick.AddListener(RefreshRoomList);
    //    }

    //    private void RefreshRoomList()
    //    {
    //        var playerOnlineInfo = GameManager.instance.PlayerOnlineInfo;
    //        _networkManager.matchMaker.ListMatches(0, _amountOfMatchesToShow, _matchNameFilter, _matchPrivateFilter, playerOnlineInfo.PlayerScore, 0, OnMatchList);
    //        _statusText.text = "Loading...";
    //    }

    //    private void OnMatchList(bool succes, string extendedInfo, List<MatchInfoSnapshot> matchInfoSnapshots)
    //    {
    //        if (!succes || matchInfoSnapshots == null)
    //        {
    //            _statusText.text = "Couldn't get room list";
    //            return;
    //        }


    //        var playerOnlineInfo = GameManager.instance.PlayerOnlineInfo;
    //        matchInfoSnapshots.InRange(playerOnlineInfo.PlayerScore);

    //        if (matchInfoSnapshots.Count == 0)
    //        {
    //            _statusText.text = "No rooms at the moment";
    //            return;
    //        }

    //        var matchInfo = matchInfoSnapshots[Random.Range(0, matchInfoSnapshots.Count)];
    //        JoinRoom(matchInfo, playerOnlineInfo);
    //    }

    //    private void JoinRoom(MatchInfoSnapshot matchInfoSnapshot, PlayerOnlineInfo playerOnlineInfo)
    //    {
    //        _networkManager.matchMaker.JoinMatch(matchInfoSnapshot.networkId, "", "", "", playerOnlineInfo.PlayerScore, 0, _networkManager.OnMatchCreate);
    //        _statusText.text = string.Format("Connecting to: {0}", matchInfoSnapshot.name);
    //    }
    //}
}