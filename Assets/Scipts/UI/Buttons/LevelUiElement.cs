﻿using UnityEngine;
using UnityEngine.UI;
using Brawler.LevelManagment;
using Brawler.Pooling;

namespace Brawler.UI
{
    public class LevelUiElement : BaseUiElement<Level>
    {
        public override Component Component { get { return this; } }

        [SerializeField] private Image _image;

        public override void Init(Level level, CallBack<Level> callBack)
        {
            base.Init(level, callBack);

            transform.name = string.Format("Selecting: {0}", Item.LevelData.LevelName);
            SetText(Item.LevelData.LevelName);
            _image.sprite = level.LevelSprite;
        }

        public override void OnDisable()
        {
            PoolManager.Instance.ReturnToPool(this);
        }
    }
}