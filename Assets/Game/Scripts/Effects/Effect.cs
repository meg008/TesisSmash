using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect : ScriptableObject
{
    public abstract void AddEffect(GameObject executer, GameObject target);    
    protected abstract void ApplyEffect(GameObject executer, GameObject target);
    protected virtual void RemoveEffect(GameObject executer, GameObject target) { }
}
