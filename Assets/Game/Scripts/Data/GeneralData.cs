using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GeneralData
{
    [SerializeField] private string name;
    [SerializeField] private string lore;
    [SerializeField] private Sprite icon;

    public string Name
    {
        get
        {
            return name;
        }
    }
    public string Lore
    {
        get
        {
            return lore;
        }
    }
    public Sprite Icon
    {
        get
        {
            return icon;
        }
    }
}
