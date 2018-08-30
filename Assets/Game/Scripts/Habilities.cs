using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Habilities : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;

    private FloatEvent onUltimatePercentChange = new FloatEvent();
    private AnimatorEventHandler animHandler;
    private float ultimatePercent;

    public HabilitiesData Data { get; set; }
    public FloatEvent OnUltimatePercentChange
    {
        get
        {
            return onUltimatePercentChange;
        }
    }
    public float UltimatePercent
    {
        get
        {
            return ultimatePercent;
        }
        set
        {
            ultimatePercent = Mathf.Clamp01(value);
            onUltimatePercentChange.Invoke(ultimatePercent);
            print(ultimatePercent);
        }
    }
    private Skill basicAttack
    {
        get
        {
            return Data.BasicAttack;
        }
    }
    private Skill heavyAttack
    {
        get
        {
            return Data.HeavyAttack;
        }
    }
    private Skill ultimate
    {
        get
        {
            return Data.Ultimate;
        }
    }

    private void Awake()
    {
        animHandler = GetComponentInChildren<AnimatorEventHandler>();
        animHandler.OnBasicAttack.AddListener(BasicAttackCallback);
        animHandler.OnHeavyAttack.AddListener(HeavyAttackCallback);
        animHandler.OnUltimate.AddListener(UltimateCallback);
    }

    public void Attack(AttackType type)
    {
        if (type == AttackType.Basic)
        {
            var attack = Mathf.RoundToInt(Random.Range(1, 4));
            animHandler.Anim.SetInteger("BasicAttack", attack);
        }
        else if (type == AttackType.ChargeHeavy)
        {
            animHandler.Anim.SetBool("HeavyAttack", true);
        }
        else if (type == AttackType.Heavy)
        {
            animHandler.Anim.SetBool("HeavyAttack", false);
        }
        else if (type == AttackType.Ultimate && ultimatePercent >= 1)
        {
            animHandler.Anim.SetTrigger("Ultimate");
        }
    }

    public void BasicAttackCallback()
    {
        if (basicAttack == null) return;
        basicAttack.Execute(this, attackPoint.position);
    }

    public void HeavyAttackCallback()
    {
        if (heavyAttack == null) return;
        heavyAttack.Execute(this, attackPoint.position);
    }

    public void UltimateCallback()
    {
        if (ultimate == null) return;
        ultimate.Execute(this, attackPoint.position);
        ultimatePercent = 0;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPoint.position, 0.5f);
    }
}

public enum AttackType
{
    Basic,
    ChargeHeavy,
    Heavy,
    Ultimate
}
