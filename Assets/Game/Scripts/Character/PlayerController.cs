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

        if (Input.GetButtonDown("Block" + ID.ToString()))
        {
            character.Attack(AttackType.Block);
            character.IsBlocking = true;
        }

        if (Input.GetButtonUp("Block" + ID.ToString()))
        { 
            character.Attack(AttackType.ChargeBlock);
            character.IsBlocking = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
            character.UltPercent += 0.2f;

        character.Move(Input.GetAxis("Horizontal" + ID.ToString()), Input.GetAxis("Vertical" + ID.ToString()));
    }

    public void SpawnCharacter()
    {
        var pos = Spawner.Instance.GetPlayerStartPos(ID);
        character = Instantiate(SelectedCharacter, pos, Quaternion.identity);
        character.DisplayName = "Player " + ID.ToString();
        switch (ID)
        {
            case 1:
                character.Pointer.color = Color.red;
                break;
            case 2:
                character.Pointer.color = Color.black;
                break;
            case 3:
                character.Pointer.color = Color.blue;
                break;
            case 4:
                character.Pointer.color = Color.green;
                break;

        }
    }
}