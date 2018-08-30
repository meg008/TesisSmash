using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TickEffect : Effect
{
    [SerializeField] private int ticks;
    [SerializeField] private float tickInterval;

    public override void AddEffect(GameObject executer, GameObject target)
    {
        EffectManager.Instance.TickEffect(executer, target, ApplyEffect, RemoveEffect, ticks, tickInterval);
    }
}
