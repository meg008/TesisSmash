using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{   
    int maxNumbersOfPlayers = 4;
    public Button go;
    private void Start()
    {        
        go.onClick.AddListener(StartGame);
    }

    private void StartGame()
    {
               
        GameManager.Instance.PlayersToStart = maxNumbersOfPlayers;
    }
}
