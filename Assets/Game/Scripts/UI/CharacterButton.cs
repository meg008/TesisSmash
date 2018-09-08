using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class IntEvent : UnityEvent<int> { }

public class CharacterButton : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private Image image;

    private IntEvent onClick = new IntEvent();
    private int index;

    public IntEvent OnClick
    {
        get
        {
            return onClick;
        }
    }

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(ClickCallback);
        
    }

    private void ClickCallback()
    {
        onClick.Invoke(index);
    }

    public void SetCharacter(GeneralData data, int index)
    {
        this.index = index;
        text.text = data.Name;
        image.sprite = data.Icon;
    }
}
