using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shield : MonoBehaviour
{
    private FloatEvent onShieldChange = new FloatEvent();
    private UnityEvent onShieldBreak = new UnityEvent();
    private int shieldAmount;

    public ShieldData Data { get; set; }
    public int BonusShield { get; set; }

    //Eventos
    public FloatEvent OnShieldChange
    {
        get
        {
            return onShieldChange;
        }
    }
    public UnityEvent OnShieldBreak
    {
        get
        {
            return onShieldBreak;
        }
    }
    public bool Active
    {
        get
        {
            return shieldAmount > 0;
        }
    }
    private int ShieldAmmount
    {
        get
        {
            return shieldAmount;
        }

        set
        {
            shieldAmount = Mathf.Clamp(value, 0, MaxShield);
            OnShieldChange.Invoke(NormalizedShield);

            if (!Active) OnShieldBreak.Invoke();
        }
    }
    private int MaxShield
    {
        get
        {
            return Data.MaxShield;
        }
    }
    private float NormalizedShield
    {
        get
        {
            return (float)ShieldAmmount / MaxShield;
        }
    }

    private void Start()
    {
        ShieldAmmount = MaxShield;
    }

    public void Damage(int amount)
    {
        if (!Active) return;
        ShieldAmmount -= amount;
    }

    public void RecoverShield(int amount)
    {
        if (!Active) return;
        shieldAmount += amount;
    }
}