using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _picked;
    [SerializeField] private GameObject _spinButton;
    private void OnEnable()
    {
        EventManager.onSpinEnded += SpinEnded;
        EventManager.onRoundEnded += RoundEnded;
        EventManager.onSpinStarted += SpinStarted;
    }

    private void OnDisable()
    {
        EventManager.onSpinEnded -= SpinEnded;
        EventManager.onRoundEnded += RoundEnded;
    }

    void SpinEnded()
    {
        _picked.gameObject.SetActive(true);
    }

    void RoundEnded()
    {
        _picked.gameObject.SetActive(false);
        StartCoroutine(RoundEndedRoutine());
    }
    IEnumerator RoundEndedRoutine()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        _spinButton.gameObject.SetActive(true);

    }
    void SpinStarted()
    {
        _spinButton.gameObject.SetActive(false);
    }
}