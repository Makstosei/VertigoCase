using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PanelAnimation : MonoBehaviour
{

    private void OnEnable()
    {
        EventManager.onStart += StartEvent;
    }

    private void OnDisable()
    {
        EventManager.onStart -= StartEvent;
    }
    void StartEvent()
    {
        StartCoroutine(StartRoutine());
    }

    IEnumerator StartRoutine()
    {
        Vector3 temp = transform.localScale;
        transform.DORotate(new Vector3(0, 0, 360), 1);
        transform.DOScale(Vector3.zero, 0.25f);
        yield return new WaitForSeconds(0.5f);
        transform.DOScale(temp, 0.5f).SetEase(Ease.InOutBounce);
    }
}
