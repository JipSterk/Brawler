using Brawler.Characters;
using Brawler.Pooling;
using UnityEngine;
using UnityEngine.UI;

namespace Brawler.UI
{
    //public class CharacterUiElement : BaseUiElement<Character>
    //{
    //    public override Component Component { get { return this; } }

    //    [SerializeField] private Image _characterImage;

    //    public override void Init(Character character, Callback<Character> callback)
    //    {
    //        Item = character;

    //        transform.name = string.Format("{0} UIProfile", Item.CharacterInfo.CharacterName);
    //        _characterImage.sprite = Item.CharacterPortrait;
    //        Item.OnCharacterDamage += UpdateCharacterInfoUi;
    //    }
        
    //    private void UpdateCharacterInfoUi(float procent)
    //    {
    //        Text.text = string.Format("{0:P}", procent);
    //    }
        
    //    public override void OnDisable()
    //    {
    //        PoolManager.Instance.ReturnToPool(this);
    //    }
    //}
}