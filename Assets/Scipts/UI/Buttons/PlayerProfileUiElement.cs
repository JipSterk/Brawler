using Brawler.CustomInput;
using Brawler.Pooling;
using UnityEngine;

namespace Brawler.UI
{
    public class PlayerProfileUiElement : BaseUiElement<PlayerControlsProfile>
    {
        public override Component Component { get { return this; } }

        public override void Init(PlayerControlsProfile playerControlsProfile, CallBack<PlayerControlsProfile> callBack)
        {
            base.Init(playerControlsProfile, callBack);

            transform.name = string.Format("Selecting: {0}", Item.ProfileName);
            SetText(Item.ProfileName);
        }

        public override void OnDisable()
        {
            PoolManager.Instance.ReturnToPool(this);
        }
    }
}