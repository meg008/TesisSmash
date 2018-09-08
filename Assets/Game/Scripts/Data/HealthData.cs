using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HealthData
{
    [SerializeField] private int maxHealth;

    public int MaxHealth
    {
        get
        {
            return maxHealth;
        }
    }
}