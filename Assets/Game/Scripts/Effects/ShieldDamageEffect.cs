using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/ShieldDamage")]
public class ShieldDamageEffect : InstantEffect
{
    [SerializeField] private int damage;
    [SerializeField] private float force;
    [SerializeField] private Vector3 dirFromForward;

    private Movement mov;
    private Character chara;

    protected override void ApplyEffect(GameObject executer, GameObject target)
    {
        target.GetComponent<Shield>().Damage(damage);

        chara = target.GetComponent<Character>();
        if (chara != null)
            if (!chara.IsBlocking)
            {
                var dir = Vector3.Normalize(executer.transform.forward + dirFromForward);
                var finalForce = dir * force;
                target.GetComponent<Rigidbody>().AddForce(finalForce);
            }
    }
}