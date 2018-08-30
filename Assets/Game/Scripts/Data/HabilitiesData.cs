using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HabilitiesData
{
    [SerializeField] private Skill basicAttack;
    [SerializeField] private Skill heavyAttack;
    [SerializeField] private Skill ultimate;
    
    public Skill BasicAttack
    {
        get
        {
            return basicAttack;
        }
    }
    public Skill HeavyAttack
    {
        get
        {
            return heavyAttack;
        }
    }
    public Skill Ultimate
    {
        get
        {
            return ultimate;
        }
    }
}
