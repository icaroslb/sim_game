using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class S_Shopkeeper : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] private S_Character character;
    [SerializeField] private GameObject canvasShop;

    void Start()
    {
        character.Initialize(S_Item.CharacterType.Shopkeeper);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        canvasShop.SetActive(true);
    }
}
