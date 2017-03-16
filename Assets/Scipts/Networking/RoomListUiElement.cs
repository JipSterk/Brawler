using Brawler.Pooling;
using Brawler.UI;
using Steamworks;
using UnityEngine;

namespace Brawler.Networking
{
    public class RoomListUiElement : BaseUiElement<CSteamID>
    {
        public override Component Component { get { return this; } }

        public override void Init(CSteamID cSteamId, Callback<CSteamID> callback)
        {
            base.Init(cSteamId, callback);
            var lobbyName = SteamMatchmaking.GetLobbyData(Item, "Name");
            var lobbyCurrentSize = SteamMatchmaking.GetLobbyData(Item, "CurrentSize");

            Text.text = string.Format("{0} ({1}/2", lobbyName, lobbyCurrentSize);
        }

        public override void OnDisable()
        {
            PoolManager.Instance.ReturnToPool(this);
        }
    }
}