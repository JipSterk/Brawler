using Brawler.CustomInput;
using Brawler.Pooling;
using UnityEngine;

namespace Brawler.UI
{
    public class PlayerProfileUiElement : BaseUiElement<PlayerControlsProfile>
    {
        public override Component Component { get { return this; } }

        public override void Init(PlayerControlsProfile playerControlsProfile, Callback<PlayerControlsProfile> callback)
        {
            base.Init(playerControlsProfile, callback);
            
            transform.name = string.Format("Selecting: {0}", Item.ProfileName);
            Text.text = Item.ProfileName;
        }

        public override void OnDisable()
        {
            PoolManager.Instance.ReturnToPool(this);
        }
    }
}