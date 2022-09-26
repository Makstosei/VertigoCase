using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New PrizeSO", menuName = "ScriptableObjects/Misc/PrizeSO")]

public class PrizeSO : ScriptableObject
{
    [SerializeField] public string itemName;
    [SerializeField] public string logoName;
    [SerializeField] public string backgroundSpriteName;
    [SerializeField] public int _maxAmount,_minAmount;
    [SerializeField] public Color color;
    [SerializeField] public float Amount;
    [SerializeField] public bool isBomb;


    public float GetAmount()
    {
        Amount = Random.Range(_minAmount, _maxAmount+1);
        return Amount;
    }

    public void SetNewAmount(float AddedAmount)
    {
        Amount += AddedAmount;
    }

}
