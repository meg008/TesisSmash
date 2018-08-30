using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/Damage")]
public class DamageEffect : InstantEffect
{
    [SerializeField] private int damage;

    protected override void ApplyEffect(GameObject executer, GameObject target)
    {
        target.GetComponent<Health>().Damage(damage);
    }
}
