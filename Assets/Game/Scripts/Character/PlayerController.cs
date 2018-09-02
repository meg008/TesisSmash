using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Character character;
    
    public int ID { get; private set; }
    public Character SelectedCharacter { get; set; }
    public Character Character
    {
        get
        {
            return character;
        }
    }

    private void Awake()
    {
        ID = GameManager.Instance.AddPlayer(this);
        GameManager.Instance.OnGameStart.AddListener(SpawnCharacter);
    }

    private void Update()
    {
        if (!character || !character.Alive) return;

        if (Input.GetButtonDown("Basic" + ID.ToString()))
            character.Attack(AttackType.Basic);

        if (Input.GetButtonDown("Heavy" + ID.ToString()))
            character.Attack(AttackType.ChargeHeavy);

        if (Input.GetButtonUp("Heavy" + ID.ToString()))
            character.Attack(AttackType.Heavy);

        if (Input.GetButtonUp("Ult" + ID.ToString()))
            character.Attack(AttackType.Ultimate);

        if (Input.GetButtonDown("Jump" + ID.ToString()))
            character.Jump();

        //Agregado Block
        if (Input.GetButtonDown("Block" + ID.ToString()))
			character.Attack(AttackType.Block);
		
        if (Input.GetButtonUp("Block" + ID.ToString()))
			character.Attack(AttackType.ChargeBlock);

        if (Input.GetKeyDown(KeyCode.Space))
            character.UltPercent += 0.2f;

        character.Move(Input.GetAxis("Horizontal" + ID.ToString()), Input.GetAxis("Vertical" + ID.ToString()));
    }

    public void SpawnCharacter()
    {
        var pos = Spawner.Instance.GetPlayerStartPos(ID);
        character = Instantiate(SelectedCharacter, pos, Quaternion.identity);
        character.DisplayName = "Player " + ID.ToString();
    }
}