using Brawler.UI;
using UnityEngine.Networking.Match;

namespace Brawler.Networking
{
    public class RoomListItem : BaseUiElement<MatchInfoSnapshot>
    {
        public override void Init(MatchInfoSnapshot matchInfoSnapshot, CallBack<MatchInfoSnapshot> callBack)
        {
            base.Init(matchInfoSnapshot, callBack);
            SetText(string.Format("{0} ({1}/{2}", _t.name, _t.currentSize, _t.maxSize));
        }
    }
}