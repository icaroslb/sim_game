using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static S_Item;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    
    [SerializeField] private S_Player player;

    public event EventHandler ChangeClothes;

    void Awake()
    {
        instance = this;
        player = GameObject.FindObjectOfType<S_Player>();
    }

    // Called when any clothing is clicked to change and calls characters to change the clothing
    public void OnChangeClothes (object sender, EventArgs e)
    {
        ChangeClothes?.Invoke(sender, EventArgs.Empty);
    }

    // Called when try to buy or sell an item. If it is buy, verify if it can be bought
    public void OnItemBuySell (object sender, EventArgs e)
    {
        S_StoreItemSlot slot = sender as S_StoreItemSlot;

        if (slot.isSold)
        {
            player.Sell(slot.item);
            slot.Sell();
        }
        else
        {
            if (player.Buy(slot.item))
                slot.Buy();
        }
    }

    // Get pocket from player
    public S_Pocket GetPocket ()
    {
        return player.pocket;
    }
}
