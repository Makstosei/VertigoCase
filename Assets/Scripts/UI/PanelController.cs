using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using TMPro;

public class PanelController : MonoBehaviour
{
    [SerializeField] private GameObject _panelLevelPrefab;
    [SerializeField] private FloatSO _currentLevel;
    [SerializeField] private GameObject _panelBase;
    [SerializeField] private SpriteAtlas _atlas;
    [SerializeField] private List<GameObject> _panelLevelList = new List<GameObject>();

    private void OnEnable()
    {
        EventManager.onStart += StartEvent;
        EventManager.onRoundEnded += CreateNext;
    }

    private void OnDisable()
    {
        EventManager.onStart -= StartEvent;
        EventManager.onRoundEnded -= CreateNext;
    }

    void StartEvent()
    {
        for (float i = _currentLevel.Value - 7; i < _currentLevel.Value + 1; i++)
        {
            if (i > 0)
            {
                CreateNew(i);
            }
        }
    }

    void CreateNew(float i)
    {
        GameObject temp = Instantiate(_panelLevelPrefab, _panelBase.transform);
        _panelLevelList.Add(temp);
        Image tempImage = temp.GetComponentInChildren<Image>();
        TextMeshProUGUI tempText = temp.GetComponentInChildren<TextMeshProUGUI>();

        tempText.text = i.ToString();

        if (i < 5 && i == 1 || i % 5 == 0 && i % 30 != 0)
        {
            tempImage.sprite = _atlas.GetSprite("ui_card_panel_zone_super");
        }
        else if (i % 30 == 0)
        {
            tempImage.sprite = _atlas.GetSprite("ui_card_panel_zone_current");
        }
        else
        {
            tempImage.sprite = _atlas.GetSprite("ui_card_panel_zone_bg");
        }

    }

    void CreateNext()
    {
        CreateNew(_currentLevel.Value);
        GameObject temp = _panelLevelList[0];
        if (_panelLevelList.Count > 8)
        {
            _panelLevelList.RemoveAt(0);
            Destroy(temp);
        }

    }



}
