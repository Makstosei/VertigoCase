using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrizeController : MonoBehaviour
{
    [SerializeField] private Image _prizeImage;
    [SerializeField] private Image _backgroundImage;
    [SerializeField] private GameObject _positionRef;
    [SerializeField] private PrizeSO _prize;

    void Update()
    {
        transform.position = _positionRef.transform.position;
    }

    public void LogoUpdate(Sprite _prizeSprite,Sprite _backgroundSprite,Color _color) 
    {
        _prizeImage.sprite = _prizeSprite;
        _backgroundImage.sprite = _backgroundSprite;
        _backgroundImage.color = _color;
    }


    public void PositionRefer(GameObject refer)
    {
        _positionRef = refer;
    }


    public void SetPrize(PrizeSO prizeRef)
    {
        _prize = prizeRef;
    } 

    public PrizeSO GetPrize()
    {
        return _prize;
    }

}
