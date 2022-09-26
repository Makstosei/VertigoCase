using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpinManager : MonoBehaviour
{
    [SerializeField] private GameObject _wheelBase;
    [SerializeField] private bool _clockwiseTurn;
    [SerializeField] private float _spinDuration = 3;
    [SerializeField] private float _delayTime;
    [SerializeField] private int _speed;
    [SerializeField] private bool _isSpinning;
    [SerializeField] private FloatSO _currentlevel;

    private void OnEnable()
    {
        EventManager.onSpinStarted += SpinEvent;
    }
    private void OnDisable()
    {
        EventManager.onSpinStarted -= SpinEvent;
    }

    void SpinEvent()
    {
        if (!_isSpinning)
        {
            _isSpinning = true;
            StartCoroutine(Spin());
        }

    }


    IEnumerator Spin()
    {
        _speed = Random.Range(1, 9);
        ScaleEffect();
        if (_clockwiseTurn)
        {
            _wheelBase.transform.DORotate(new Vector3(0, 0, _speed * 45 + 720), _spinDuration, RotateMode.LocalAxisAdd);
        }
        else
        {
            _wheelBase.transform.DORotate(new Vector3(0, 0, -1 * (_speed * 45 + 720)), _spinDuration, RotateMode.LocalAxisAdd);
        }

        yield return new WaitForSeconds(_spinDuration + _delayTime);
        
        SpinEnded();
    }

    void ScaleEffect()
    {
        Vector3 _originalScale = Vector3.one;
        Vector3 _scaleTo = _originalScale * 1.1f;
        _wheelBase.transform.DOScale(_scaleTo, _spinDuration / 2).SetEase(Ease.InOutSine).OnComplete(() =>
        {
            _wheelBase.transform.DOScale(_originalScale, _spinDuration / 2).SetEase(Ease.OutBounce).onComplete();
        });
    }

    void SpinEnded()
    {
        _isSpinning = false;
        _currentlevel.ChangeAmountBy(1);
        EventManager.Instance.EndSpin();
    }


}
