using Brawler.GameSettings;
using Brawler.UI;
using UnityEngine;
using UnityEngine.Networking;

namespace Brawler.Networking
{
    public class HostNetworkGame : MonoBehaviour
    {
        private uint _matchSize = 2;
        private string _matchName;
        private string _matchPassword;
        private bool _matchAdvertise;
        private NetworkManager _networkManger;
        
        private void Start()
        {
            _networkManger = NetworkManager.singleton;
            SetupUi();
        }

        private void SetupUi()
        {
            InterfaceManager.Instance.InitNetworkUi(SetupMatch, CreateRoom);
        }

        private void SetupMatch(string matchName, string matchPassword, bool matchAdvertise)
        {
            _matchName = matchName;
            _matchPassword = matchPassword;
            _matchAdvertise = matchAdvertise;
        }

        private void CreateRoom()
        {
            if (string.IsNullOrEmpty(_matchName))
                _matchName = RandomMatchName();

            var playerOnlineInfo = GameManager.Instance.PlayerOnlineInfo;
            _networkManger.matchMaker.CreateMatch(_matchName, _matchSize, _matchAdvertise, _matchPassword, "", "", playerOnlineInfo.PlayerScore, 0, _networkManger.OnMatchCreate);
        }

        private string RandomMatchName()
        {
            return "RandomName";
        }
    }
}