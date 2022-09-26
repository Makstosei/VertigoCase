using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    #region Singleton

    private static EventManager _instance;

    public static EventManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<EventManager>();
            return _instance;
        }
    }
    #endregion

    public static Action onStart;
    public static Action onSpinStarted;
    public static Action onSpinEnded;
    public static Action onRoundEnded;
    public static Action<PrizeSO> onPrizeSelected;
    public static Action<GameObject> onPanelUpdate;
    public void GameStarted()
    {
        onStart.Invoke();
    }

    public void StartSpin()
    {
        onSpinStarted.Invoke();
    }
    public void EndSpin()
    {
        onSpinEnded.Invoke();
    }

    public void PanelUpdate(GameObject obj)
    {
        onPanelUpdate.Invoke(obj);
    }

    public void RoundEnd()
    {
        onRoundEnded.Invoke();
    }
    public void PrizeSelected(PrizeSO prize)
    {
        onPrizeSelected.Invoke(prize);
    }

}
