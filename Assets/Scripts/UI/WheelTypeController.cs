using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;
using UnityEngine.U2D;
using DG.Tweening;

public class WheelTypeController : MonoBehaviour
{
    [SerializeField] private WheelTypeSO _bronze, _silver, _gold;
    [SerializeField] private Image _Base, _indicator;
    [SerializeField] private SpriteAtlas _atlas;
    [SerializeField] private FloatSO _currentlevel;
    [SerializeField] private List<GameObject> positionReferances;
    [SerializeField] private GameObject _prizeHolder;
    [SerializeField] private GameObject _prizePrefab;
    [SerializeField] private List<GameObject> _spawnedPrizes;

    private void OnEnable()
    {
        EventManager.onRoundEnded += SetWheel;
    }

    private void OnDisable()
    {
        EventManager.onRoundEnded -= SetWheel;
    }



    void Start()
    {
        SetWheel();
        EventManager.Instance.GameStarted();
    }


    void SetWheel()
    {
        GetNewWheel();
        StartCoroutine(NewWheelEffectRoutine());
        StartCoroutine(SpawnPrizes());
    }

    private void GetNewWheel()
    {
        if (_currentlevel.Value < 5 && _currentlevel.Value == 1 || _currentlevel.Value % 5 == 0 && _currentlevel.Value % 30 != 0)
        {
            _Base.sprite = _atlas.GetSprite(_silver.wheelbackgroundname);
            _indicator.sprite = _atlas.GetSprite(_silver.indicatorname);
            _silver.GetPrizes();
        }
        else if (_currentlevel.Value % 30 == 0)
        {
            _Base.sprite = _atlas.GetSprite(_gold.wheelbackgroundname);
            _indicator.sprite = _atlas.GetSprite(_gold.indicatorname);
            _gold.GetPrizes();
        }
        else
        {
            _Base.sprite = _atlas.GetSprite(_bronze.wheelbackgroundname);
            _indicator.sprite = _atlas.GetSprite(_bronze.indicatorname);
            _bronze.GetPrizes();
        }
    }

    WheelTypeSO GetCurrentWheel()
    {

        if (_currentlevel.Value < 5 && _currentlevel.Value == 1 || _currentlevel.Value % 5 == 0 && _currentlevel.Value % 30 != 0)
        {
            return _silver;
        }
        else if (_currentlevel.Value % 30 == 0)
        {
            return _gold;
        }
        else
        {
            return _bronze;
        }
    }


    IEnumerator NewWheelEffectRoutine()
    {
        Vector3 temp = _Base.gameObject.transform.localScale;
        _Base.gameObject.transform.localEulerAngles = Vector3.zero;
        _Base.gameObject.transform.DOScale(Vector3.zero, 0.5f);
        yield return new WaitForSeconds(0.5f);
        _Base.gameObject.transform.DOScale(temp, 0.5f).SetEase(Ease.InOutBounce);
    }


    IEnumerator SpawnPrizes()
    {
        if (_spawnedPrizes.Count > 1)
        {
            int count = _spawnedPrizes.Count - 1;
            for (int i = count; i > -1; i--)
            {
                GameObject temp = _spawnedPrizes[i];
                _spawnedPrizes.RemoveAt(i);
                Destroy(temp);
            }
        }
        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i < positionReferances.Count; i++)
        {

            WheelTypeSO current = GetCurrentWheel();
            GameObject prizeTemp = Instantiate(_prizePrefab, _prizeHolder.transform);
            _spawnedPrizes.Add(prizeTemp);
            PrizeController prizeTempController = prizeTemp.GetComponent<PrizeController>();
            prizeTempController.PositionRefer(positionReferances[i]);
            prizeTempController.SetPrize(current.prizes[i]);
            prizeTempController.LogoUpdate(_atlas.GetSprite(current.prizes[i].logoName), _atlas.GetSprite(current.prizes[i].backgroundSpriteName), current.prizes[i].color);
        }
    }


}
