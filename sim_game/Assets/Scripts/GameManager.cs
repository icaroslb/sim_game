using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }
    [SerializeField] private List<S_Character> playerCharacters;
    
    // Start is called before the first frame update
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
}
