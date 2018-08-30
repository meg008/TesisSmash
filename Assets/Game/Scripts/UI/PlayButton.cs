using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private InputField inputField;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
        if (inputField.text == "") return;

        var players = Mathf.Clamp(Convert.ToInt32(inputField.text), 0, 4);
        GameManager.Instance.PlayersToStart = players;
    }
}
