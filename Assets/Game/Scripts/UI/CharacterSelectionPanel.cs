using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectionPanel : MonoBehaviour
{
    [SerializeField] private List<Character> characters;
    [SerializeField] private CharacterButton characterButtonPrefab;
    [SerializeField] private Transform selectorPanel;
    [SerializeField] private Text tittle;

    private int playerIndex;

    private void Start()
    {
        for (int i = 0; i < characters.Count; i++)
        {
            var button = Instantiate(characterButtonPrefab, selectorPanel);
            button.SetCharacter(characters[i].Type.GeneralData, i);
            button.OnClick.AddListener(SetCharacterToPlayer);
        }
    }

    private void SetCharacterToPlayer(int index)
    {
        var character = characters[index];
        GameManager.Instance.Players[playerIndex].SelectedCharacter = character;
        playerIndex++;

        if (playerIndex >= GameManager.Instance.PlayersToStart)
        {
            GameManager.Instance.StartGame();
            gameObject.SetActive(false);
        }

        tittle.text = "Player " + (playerIndex + 1) + " turn to pick";
    }
}
