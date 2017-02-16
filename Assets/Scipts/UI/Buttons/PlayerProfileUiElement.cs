using Brawler.CustomInput;

namespace Brawler.UI
{
    public class PlayerProfileUiElement : BaseUiElement<PlayerControlsProfile>
    {
        public override void Init(PlayerControlsProfile playerControlsProfile, CallBack<PlayerControlsProfile> callBack)
        {
            base.Init(playerControlsProfile, callBack);

            transform.name = string.Format("Selecting: {0}", Item.ProfileName);
            SetText(Item.ProfileName);
        }
    }
}