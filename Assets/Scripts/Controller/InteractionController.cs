using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
public class InteractionController : MonoBehaviour
{
    [SerializeField] private GameObject _ui_canvas;
    [SerializeField] private GraphicRaycaster _ui_raycasyer;
    [SerializeField] private GameObject _spinbutton;
    [SerializeField] private GameObject _pickedBackground;
    [SerializeField] private bool _isRoundStarted, _isSpinStarted;
    private PointerEventData _clickData;
    private List<RaycastResult> _clickResults;

    private void OnEnable()
    {
        EventManager.onRoundEnded += RoundEnded;
    }

    private void OnDisable()
    {
        EventManager.onRoundEnded -= RoundEnded;
    }


    void RoundEnded()
    {
        _isRoundStarted = false;
        StartCoroutine(RoundEndRoutine());
    }

    IEnumerator RoundEndRoutine()
    {
        yield return new WaitForSecondsRealtime(0.2f);
        _isSpinStarted = false;
    }

    private void OnValidate()
    {
        _ui_raycasyer = _ui_canvas.GetComponent<GraphicRaycaster>();
        _clickData = new PointerEventData(EventSystem.current);
        _clickResults = new List<RaycastResult>();
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _clickData.position = Input.mousePosition;
            _clickResults.Clear();
            _ui_raycasyer.Raycast(_clickData, _clickResults);
        }
        GetUiElementsClicked();

    }


    private void GetUiElementsClicked()
    {

        foreach (var result in _clickResults)
        {
            GameObject ui_element = result.gameObject;
            if (ui_element == _spinbutton && !_isSpinStarted)
            {
                _isRoundStarted = true;
                _isSpinStarted = true;
                EventManager.Instance.StartSpin();
            }
            else if (ui_element == _pickedBackground && _isRoundStarted)
            {
                EventManager.Instance.RoundEnd();
            }
        }

    }


}
