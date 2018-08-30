using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FloatEvent : UnityEvent<float> { }

public class Health : MonoBehaviour
{
    private FloatEvent onLifeChange = new FloatEvent();
    private UnityEvent onDeath = new UnityEvent();
    private int life;

    public HealthData Data { get; set; }
    public int BonusLife { get; set; }
    public FloatEvent OnLifeChange
    {
        get
        {
            return onLifeChange;
        }
    }
    public UnityEvent OnDeath
    {
        get
        {
            return onDeath;
        }
    }
    public bool Alive
    {
        get
        {
            return life > 0;
        }
    }
    private int Life
    {
        get
        {
            return life;
        }

        set
        {
            life = Mathf.Clamp(value, 0, MaxLife);
            OnLifeChange.Invoke(NormalizedLife);

            if (!Alive) OnDeath.Invoke();
        }
    }
    private int MaxLife
    {
        get
        {
            return Data.MaxHealth + BonusLife;
        }
    }
    private float NormalizedLife
    {
        get
        {
            return (float)life / MaxLife;
        }
    }

    private void Start()
    {
        life = MaxLife;
    }

    public void Damage(int amount)
    {
        if (!Alive) return;
        Life -= amount;
    }

    public void Heal(int amount)
    {
        if (!Alive) return;
        Life += amount;
    }
}
