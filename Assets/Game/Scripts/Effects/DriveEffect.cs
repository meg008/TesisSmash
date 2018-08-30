using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/Drive")]
public class DriveEffect : InstantEffect
{
    [SerializeField] private float force;
    [SerializeField] private Vector3 dirFromForward;

    protected override void ApplyEffect(GameObject executer, GameObject target)
    {
        var dir = Vector3.Normalize(executer.transform.forward + dirFromForward);
        var finalForce = dir * force;
        target.GetComponent<Rigidbody>().AddForce(finalForce);
    }
}
