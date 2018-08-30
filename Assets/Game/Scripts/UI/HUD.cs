﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] private Transform topPanel;
    [SerializeField] private PlayerInfoDisplay playerInfoPrefab;

    private void Start()
    {
        OnGameStart();
    }

    private void OnGameStart()
    {
        var players = GameManager.Instance.Players;
        for (int i = 0; i < players.Count; i++)
        {
            var p = Instantiate(playerInfoPrefab, topPanel);
            p.SetPlayer(players[i]);
        }
    }
}
