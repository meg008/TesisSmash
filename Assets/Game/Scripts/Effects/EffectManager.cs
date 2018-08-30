using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public static EffectManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void TimeEffect(GameObject executer, GameObject target, Action<GameObject, GameObject> ApplyEffect, Action<GameObject, GameObject> RemoveEffect, float duration)
    {
        StartCoroutine(TimeEffectCoroutine(executer, target, ApplyEffect, RemoveEffect, duration));
    }

    public void TickEffect(GameObject executer, GameObject target, Action<GameObject, GameObject> ApplyEffect, Action<GameObject, GameObject> RemoveEffect, int ticks, float tickInterval)
    {
        StartCoroutine(TickEffectCoroutine(executer, target, ApplyEffect, RemoveEffect, ticks, tickInterval));
    }

    private IEnumerator TimeEffectCoroutine(GameObject executer, GameObject target, Action<GameObject, GameObject> ApplyEffect, Action<GameObject, GameObject> RemoveEffect, float duration)
    {
        ApplyEffect(executer, target);

        yield return new WaitForSeconds(duration);

        RemoveEffect(executer, target);
    }

    private IEnumerator TickEffectCoroutine(GameObject executer, GameObject target, Action<GameObject, GameObject> ApplyEffect, Action<GameObject, GameObject> RemoveEffect, int ticks, float tickInterval)
    {
        for (int i = 0; i < ticks; i++)
        {
            ApplyEffect(executer, target);

            if (i < ticks - 1)
                yield return new WaitForSeconds(tickInterval);
        }

        RemoveEffect(executer, target);
    }
}
