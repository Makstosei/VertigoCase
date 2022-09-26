using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.U2D;

public class PickedItemController : MonoBehaviour
{
    [SerializeField] private Image _itemLogo, _background1, _background2;
    [SerializeField] private Color _color;
    [SerializeField] private TextMeshProUGUI _itemName;
    [SerializeField] private TextMeshProUGUI _itemAmount;
    [SerializeField] private SpriteAtlas _atlas;
    [SerializeField] private FloatSO _currentLevel;

    private void OnEnable()
    {
        EventManager.onPrizeSelected += PrizeSelected;
    }

    private void OnDisable()
    {
        EventManager.onPrizeSelected -= PrizeSelected;
    }


    void PrizeSelected(PrizeSO prize)
    {
        prize.GetAmount();
        _itemLogo.sprite = _atlas.GetSprite(prize.logoName);
        _background1.sprite = _atlas.GetSprite(prize.backgroundSpriteName);
        _background2.sprite = _atlas.GetSprite("star_glow_alpha");
        _background1.color = prize.color;
        _background2.color = prize.color;
        _itemName.text = prize.itemName;
        _itemAmount.text = (prize.Amount + (int)(_currentLevel.Value * 1)).ToString();
    }

}
