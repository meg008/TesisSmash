using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private Button menuButton;

    public Text Text
    {
        get
        {
            return text;
        }
    }

    private void Awake()
    {
        menuButton.onClick.AddListener(RestartScene);
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(0);
    }
}
