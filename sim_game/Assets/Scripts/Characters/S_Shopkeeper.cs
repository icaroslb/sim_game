using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class S_Shopkeeper : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{

    [SerializeField] private S_Character character;     // Shopkeeper character
    [SerializeField] private GameObject canvasShop;     // Canvas that will appear when clicked

    // Bubble text shows when mouse hover it
    [SerializeField] private GameObject bubble;
    [SerializeField] private SpriteRenderer background;
    [SerializeField] private TextMeshPro bubbleText;

    [SerializeField] private string text;               // Text that will appear in the bubble

    void Start()
    {
        canvasShop = GameObject.Find("StoreTable");
        canvasShop.SetActive(false);

        character.Initialize(S_Item.CharacterType.Shopkeeper);

        bubbleText.SetText(text);
        bubbleText.ForceMeshUpdate();

        Vector2 space = new Vector2(1f, 0.5f);
        Vector2 textSize = bubbleText.GetRenderedValues(false);

        background.size = textSize + space;

        bubble.SetActive(false);
    }

    // Makes shop appear
    public void OnPointerClick(PointerEventData eventData)
    {
        canvasShop.SetActive(true);
    }

    // Makes bubble appear
    public void OnPointerEnter(PointerEventData eventData)
    {
        bubble.SetActive(true);
    }
    
    // Makes bubble disappear
    public void OnPointerExit(PointerEventData eventData)
    {
        bubble.SetActive(false);
    }
}
