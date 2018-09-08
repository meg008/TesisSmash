using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShieldData
{
    [SerializeField] private int maxShield;

    public int MaxShield
    {
        get
        {
            return maxShield;
        }
    }
}