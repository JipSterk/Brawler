using UnityEngine;
using UnityEngine.UI;
using Brawler.LevelManagment;

namespace Brawler.UI
{
    public class LevelUiElement : BaseUiElement<Level>
    {
        [SerializeField] private Image _image;

        public override void Init(Level level, CallBack<Level> callBack)
        {
            base.Init(level, callBack);

            transform.name = string.Format("Selecting: {0}", _t.LevelData.LevelName);
            SetText(_t.LevelData.LevelName);
            _image.sprite = level.LevelSprite;
        }
    }
}