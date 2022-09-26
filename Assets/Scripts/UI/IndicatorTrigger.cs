using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorTrigger : MonoBehaviour
{
    [SerializeField] private bool _isSpinEnded, _istriggired;

    private void OnEnable()
    {
        EventManager.onSpinEnded += SpinEnded;
        EventManager.onSpinStarted += SpinStarted;

    }
    private void OnDisable()
    {
        EventManager.onSpinEnded -= SpinEnded;
        EventManager.onSpinStarted -= SpinStarted;

    }

    void SpinStarted()
    {
        _isSpinEnded = false;
    }

    void SpinEnded()
    {
        _istriggired = false;
        _isSpinEnded = true;
    }
   

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Prize") && _isSpinEnded)
        {
            if (!_istriggired)
            {
                _istriggired = true;
                EventManager.Instance.PrizeSelected(collision.transform.parent.gameObject.GetComponent<PrizeController>().GetPrize());
                Debug.Log(collision.transform.parent.gameObject.GetComponent<PrizeController>().GetPrize().itemName);
            }
        }
    }



}
