using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterType type;
    [SerializeField] private Text displayName;

    private AnimatorEventHandler aeh;
    private Movement movement;
    private Habilities habilities;
    private Health health;

    //Agregado de Escudo
    private Shield escudo;

    public CharacterType Type
    {
        get
        {
            return type;
        }
    }
    public UnityEvent OnDeath
    {
        get
        {
            return health.OnDeath;
        }
    }
    public bool Alive
    {
        get
        {
            return health.Alive;
        }
    }
    public string DisplayName
    {
        set
        {
            if (!displayName) return;
            displayName.text = value;
        }
    }
    public float UltPercent
    {
        get
        {
            return habilities.UltimatePercent;
        }
        set
        {
            habilities.UltimatePercent = value;
        }
    }

    private void Awake()
    {
        movement = GetComponent<Movement>();
        habilities = GetComponent<Habilities>();
        health = GetComponent<Health>();

        movement.Data = type.MovementData;
        habilities.Data = type.SkillData;
        health.Data = type.HealthData;

        health.OnDeath.AddListener(OnDeathCallback);
    }

    private void Update()
    {
        if (transform.position.y < -6)
        {
            health.Damage(20);
            if (Alive) transform.position = Spawner.Instance.GetPlayerSpawnPos();
        }
    }

    public void Move(float x, float y)
    {
        movement.Move(x, y);
    }

    public void Jump()
    {
        movement.Jump();
    }

    public void Attack(AttackType type)
    {
        habilities.Attack(type);
    }

    private void OnDeathCallback()
    {
        print("Mori");
    }
}
