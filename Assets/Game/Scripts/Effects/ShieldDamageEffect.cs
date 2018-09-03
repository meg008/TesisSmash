using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/ShieldDamage")]
public class ShieldDamageEffect : InstantEffect
{
    [SerializeField] private int damage;
    [SerializeField] private float force;
    [SerializeField] private Vector3 dirFromForward;

    protected override void ApplyEffect(GameObject executer, GameObject target)
    {
        target.GetComponent<Shield>().Damage(damage);

        var dir = Vector3.Normalize(executer.transform.forward + dirFromForward);
        var finalForce = dir * force;
        target.GetComponent<Rigidbody>().AddForce(finalForce);
    }
}