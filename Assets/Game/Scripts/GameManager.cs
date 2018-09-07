using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private PlayerController playerControllerPrefab;
    [SerializeField] private GameObject HUD;
    [SerializeField] private GameOverPanel gameOverPanel;

    private UnityEvent onGameStart = new UnityEvent();
    private List<PlayerController> players = new List<PlayerController>();
    private int playersToStart;

    public int PlayersToStart
    {
        get
        {
            return playersToStart;
        }

        set
        {
            playersToStart = value;
            for (int i = 0; i < playersToStart; i++)
                Instantiate(playerControllerPrefab);
        }
    }
    public List<PlayerController> Players
    {
        get
        {
            return players;
        }
    }
    public UnityEvent OnGameStart
    {
        get
        {
            return onGameStart;
        }
    }

    private void Awake()
    {
        Instance = this;
    }

    public int AddPlayer(PlayerController p)
    {
        if (players.Count >= PlayersToStart) return 0;

        players.Add(p);
        return players.Count;
    }

    public void StartGame()
    {
        OnGameStart.Invoke();
        HUD.SetActive(true);

        for (int i = 0; i < players.Count; i++)
            players[i].Character.OnDeath.AddListener(CheckForWin);
    }

    private void CheckForWin()
    {
        var aux = new List<PlayerController>();
        for (int i = 0; i < players.Count; i++)
            if (players[i].Character.Alive)
                aux.Add(players[i]);

        if(aux.Count <= 1)
        {
            gameOverPanel.gameObject.SetActive(true);

            if (aux.Count == 0)
                gameOverPanel.Text.text = "Tie";
            else
            {
                gameOverPanel.Text.text = "Player " + aux[0].ID + " has won";
                //aux[0].gameObject.SetActive(false);
            }
            
        }
    }
}
