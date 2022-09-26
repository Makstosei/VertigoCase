using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New FloatSO", menuName = "ScriptableObjects/Variables/FloatSO")]

public class FloatSO : ScriptableObject
{
    [SerializeField]
    private float value,initialValue;

    public float Value { get => value; }


    public void ChangeAmountBy(float changeby)
    {
        value += changeby;
        value = Mathf.Clamp(value, 0f, value);
    }


    public void SetNewAmount(float newAmount)
    {
        value = newAmount;
        value = Mathf.Clamp(value, 0f, value);
    }

    public void ResetValue()
    {
        value = initialValue;
    }
}
