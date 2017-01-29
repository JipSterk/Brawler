using Brawler.CustomInput;

namespace Brawler.UI
{
    public class PlayerProfileUiElement : BaseUiElement<PlayerControlsProfile>
    {
        public override void Init(PlayerControlsProfile playerControlsProfile, CallBack<PlayerControlsProfile> callBack)
        {
            base.Init(playerControlsProfile, callBack);

            transform.name = string.Format("Selecting: {0}", _t.ProfileName);
            SetText(_t.ProfileName);
        }
    }
}