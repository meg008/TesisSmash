using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private Button menuButton;
    [SerializeField] private StandaloneInputModule standaInput;
    [SerializeField] private EventSystem eventSystemInput;
    public Text Text
    {
        get
        {
            return text;
        }
    }

    private void Awake()
    {
        eventSystemInput = EventSystem.current;
        standaInput = GameObject.Find("EventSystem").GetComponent<StandaloneInputModule>();
        menuButton.onClick.AddListener(RestartScene);
        eventSystemInput.SetSelectedGameObject(menuButton.gameObject);
        eventSystemInput.firstSelectedGameObject = eventSystemInput.currentSelectedGameObject;
    }

    private void RestartScene()
    {
        SceneManager.LoadScene(0);
    }
}
