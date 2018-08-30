using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TimeEffect : Effect
{
    [SerializeField] private float duration;

    public override void AddEffect(GameObject executer, GameObject target)
    {
        EffectManager.Instance.TimeEffect(executer, target, ApplyEffect, RemoveEffect, duration);
    }
}
