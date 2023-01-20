using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

// Controls UI the value of the player pocket
public class UI_Pocket : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI value;
    
    void Start()
    {
        S_Pocket pocket = GameManager.instance.GetPocket();
        pocket.OnPocketChange += PocketUpdate;

        value.text = pocket.money.ToString();
    }

    public void PocketUpdate(object sender, EventArgs e)
    {
        S_Pocket pocket = sender as S_Pocket;

        value.text = pocket.money.ToString();

    }
}
