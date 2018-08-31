using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCPlayerController : MonoBehaviour
{
    [SerializeField] private Character character;

    private void Update()
    {
        if (!character || !character.Alive) return;

        if (Input.GetKeyDown(KeyCode.Mouse0))
            character.Attack(AttackType.Basic);

        if (Input.GetKey(KeyCode.Mouse1))
            character.Attack(AttackType.ChargeHeavy);

        if (Input.GetKeyUp(KeyCode.Mouse1))
            character.Attack(AttackType.Heavy);

        if (Input.GetKeyDown(KeyCode.Space))
            character.Jump();

        if (Input.GetKeyDown(KeyCode.Q))
            character.Attack(AttackType.Ultimate);

        character.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}
