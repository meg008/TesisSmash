using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Block")]
public class BlockSkill : Skill
{
    [SerializeField] private float areaEffect;
    [SerializeField] private GameObject VFX;

    public override void Execute(Habilities executer, Vector3 pos)
    {
        /*
         * var results = Physics.OverlapSphere(pos, areaEffect);
        var executerHealth = executer.GetComponent<Health>();

        for (int i = 0; i < results.Length; i++)
        {
            var health = results[i].GetComponent<Health>();
            if (health == null || health == executerHealth) continue;

            executer.UltimatePercent += ultimateChargeAmount;

            Instantiate(VFX, pos, Quaternion.identity);
            for (int j = 0; j < effects.Count; j++)
                effects[j].AddEffect(executer.gameObject, results[i].gameObject);
        }
         */
    }
}