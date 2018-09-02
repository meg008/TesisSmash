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
    [SerializeField]StandaloneInputModule standaInput;
    EventSystem eventSystemInput;
    private int playerIndex;

    private void Start()
    {
        eventSystemInput = EventSystem.current;       
        standaInput = GameObject.Find("EventSystem").GetComponent<StandaloneInputModule>();
        for (int i = 0; i < characters.Count; i++)
        {
            var button = Instantiate(characterButtonPrefab, selectorPanel);
            button.SetCharacter(characters[i].Type.GeneralData, i);
            var color= button.GetComponent<Button>().colors.highlightedColor;
            color = Color.blue;
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
            standaInput.submitButton = "Submit";
            standaInput.verticalAxis = "Vertical";
            standaInput.horizontalAxis = "Horizontal";
        }
        standaInput.submitButton = "Submit"+(playerIndex+1);
        standaInput.verticalAxis = "Vertical" + (playerIndex+1);
        standaInput.horizontalAxis =  "Horizontal" + (playerIndex+1);
        tittle.text = "Player " + (playerIndex + 1) + " turn to pick";
    }
}
