using Brawler.Pooling;
using Brawler.UI;
using UnityEngine;
using UnityEngine.Networking.Match;

namespace Brawler.Networking
{
    public class RoomListItem : BaseUiElement<MatchInfoSnapshot>
    {
        public override Component Component { get { return this; } }

        public override void Init(MatchInfoSnapshot matchInfoSnapshot, CallBack<MatchInfoSnapshot> callBack)
        {
            base.Init(matchInfoSnapshot, callBack);
            SetText(string.Format("{0} ({1}/{2}", Item.name, Item.currentSize, Item.maxSize));
        }

        public override void OnDisable()
        {
            PoolManager.Instance.ReturnToPool(this);
        }
    }
}