using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CharacterSelectionPanel : MonoBehaviour
{
    [SerializeField] private List<Character> characters;
    [SerializeField] private CharacterButton characterButtonPrefab;
    [SerializeField] private Transform selectorPanel;
    [SerializeField] private Text tittle;
    [SerializeField] private CharacterButton last;
    [SerializeField] private StandaloneInputModule standaInput;
    [SerializeField] private EventSystem eventSystemInput;
    private string submit = "Submit";
    private string vertical = "Vertical";
    private string horizontal = "Horizontal";
    private int playerIndex;

    private void Start()
    {
        eventSystemInput = EventSystem.current;
        standaInput = GameObject.Find("EventSystem").GetComponent<StandaloneInputModule>();
        for (int i = 0; i < characters.Count; i++)
        {
            var button = Instantiate(characterButtonPrefab, selectorPanel);
            button.SetCharacter(characters[i].Type.GeneralData, i);
            button.OnClick.AddListener(SetCharacterToPlayer);
            last = button;
        }
        eventSystemInput.SetSelectedGameObject(last.GetComponent<Button>().gameObject);
        eventSystemInput.firstSelectedGameObject = eventSystemInput.currentSelectedGameObject;
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
            standaInput.submitButton = submit;
            standaInput.verticalAxis = vertical;
            standaInput.horizontalAxis = horizontal;
        }
        else
        {
            standaInput.submitButton = submit + (playerIndex + 1);
            standaInput.verticalAxis = vertical + (playerIndex + 1);
            standaInput.horizontalAxis = horizontal + (playerIndex + 1);
            tittle.text = "Player " + (playerIndex + 1) + " turn to pick";
        }
    }
}
