using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    [SerializeField] private List<S_Character> playerCharacters;
    [SerializeField] private S_Player player;
    
    void Awake()
    {
        instance = this;
    }

    public void OnChangeClothes (object sender, EventArgs e)
    {
        S_ClotheSlot clotheSlote = sender as S_ClotheSlot;

        foreach (S_Character c in playerCharacters)
        {
            c.ChangeClothe(clotheSlote.item.type, clotheSlote.item.id);
        }
    }

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

    public S_Pocket GetPocket ()
    {
        return player.pocket;
    }
}
