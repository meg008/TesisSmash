using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill : ScriptableObject
{
    [SerializeField] protected List<Effect> effects;

    public abstract void Execute(Habilities executer, Vector3 pos);
}
