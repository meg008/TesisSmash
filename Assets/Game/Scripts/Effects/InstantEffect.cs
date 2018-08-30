using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InstantEffect : Effect
{
    public override void AddEffect(GameObject executer, GameObject target)
    {
        ApplyEffect(executer, target);
    }
}
