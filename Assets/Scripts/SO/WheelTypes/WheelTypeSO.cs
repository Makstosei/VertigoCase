using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New WheelTypeSO", menuName = "ScriptableObjects/Misc/WheelTypeSO")]

public class WheelTypeSO : ScriptableObject
{
    [SerializeField] public string wheelName;
    [SerializeField] public string wheelbackgroundname;
    [SerializeField] public string indicatorname;
    [SerializeField] public int amountofother = 2;
    [SerializeField] public int amountoftier1 = 4;
    [SerializeField] public int amountoftier2 = 1;
    [SerializeField] public int amountoftier3 = 1;
    [SerializeField] public int amountofbomb = 1;
    [SerializeField] public float criticalmultiplier = 1;


    [SerializeField] public List<PrizeSO> prizes;
    [SerializeField] public List<PrizeSO> otherlist;
    [SerializeField] public List<PrizeSO> tier1list;
    [SerializeField] public List<PrizeSO> tier2list;
    [SerializeField] public List<PrizeSO> tier3list;
    [SerializeField] public List<PrizeSO> bomblist;
    [SerializeField] private List<PrizeSO> prizesTemp;




    public void GetPrizes()
    {
        prizes.Clear();
        prizesTemp.Clear();
        if (amountofother > 0)
        {
            for (int i = 0; i < amountofother; i++)
            {
                prizesTemp.Add(otherlist[Random.Range(0, otherlist.Count)]);
            }
        }
        if (amountoftier1 > 0)
        {
            for (int i = 0; i < amountoftier1; i++)
            {
                prizesTemp.Add(tier1list[Random.Range(0, tier1list.Count)]);
            }
        }
        if (amountoftier2 > 0)
        {
            for (int i = 0; i < amountoftier2; i++)
            {
                prizesTemp.Add(tier2list[Random.Range(0, tier2list.Count)]);
            }
        }
        if (amountoftier3 > 0)
        {
            for (int i = 0; i < amountoftier3; i++)
            {
                prizesTemp.Add(tier3list[Random.Range(0, tier3list.Count)]);
            }
        }
        if (amountofbomb > 0)
        {
            for (int i = 0; i < amountofbomb; i++)
            {
                prizesTemp.Add(bomblist[Random.Range(0, bomblist.Count)]);
            }
        }


        Randomize();
    }

    public void Randomize()
    {
        for (int i = 0; i < amountofbomb + amountofother + amountoftier1 + amountoftier2 + amountoftier3; i++)
        {
            int randomIndex = Random.Range(0, prizesTemp.Count);
            prizes.Add(prizesTemp[randomIndex]);
            prizesTemp.RemoveAt(randomIndex);
        }
    }

}