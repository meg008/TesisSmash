using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Effects/Stun")]
public class StunEffect : TimeEffect
{
    private Movement mov;
    private Character chara;

    protected override void ApplyEffect(GameObject executer, GameObject target)
    {
        chara = target.GetComponent<Character>();
        if (chara != null)
            if (!chara.IsBlocking)
            {
                mov = target.GetComponent<Movement>();
                mov.CanMove = 0;
            }
    }
    protected override void RemoveEffect(GameObject executer, GameObject target)
    {
        if (mov != null)
            mov.CanMove = 1;
    }
}