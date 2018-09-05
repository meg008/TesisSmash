using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoDisplay : MonoBehaviour
{
    [SerializeField] private Text playerName;
    [SerializeField] private Image playerImage;
    [SerializeField] private Image playerShieldBar;
    [SerializeField] private Image playerUltPercent;
    //[SerializeField] private Image playerHealthBar;

    public void SetPlayer(PlayerController p)
    {
        playerName.text = "Player " + p.ID.ToString();
        playerImage.sprite = p.Character.Type.GeneralData.Icon;
        //p.Character.GetComponent<Health>().OnLifeChange.AddListener(RefreshLife);
        p.Character.GetComponent<Shield>().OnShieldChange.AddListener(RefreshShield);
        p.Character.GetComponent<Habilities>().OnUltimatePercentChange.AddListener(RefreshUltimate);        
    }

    /*private void RefreshLife(float amount)
    {
        playerHealthBar.fillAmount = amount;
    }*/

    private void RefreshUltimate(float amount)
    {
        playerUltPercent.fillAmount = amount;
    }

    private void RefreshShield(float amount)
    {
        playerShieldBar.fillAmount = amount;
    }
}