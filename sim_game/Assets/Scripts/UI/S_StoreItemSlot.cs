using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class S_StoreItemSlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] public S_Item item { get; private set; }
    [SerializeField] private Image image;
    [SerializeField] private Transform value;
    [SerializeField] private Transform boughtTransform;
    [SerializeField] private TextMeshProUGUI price;

    public event EventHandler OnSlotCliked;

    public void Initialize(S_Item newItem, EventHandler e)
    {
        item = newItem;
        OnSlotCliked += e;

        //Image image = transform.Find("Image").GetComponent<Image>();
        //Transform value = transform.Find("Value");
        //Transform boughtTransform = transform.Find("Bought");
        //TextMeshPro price = transform.Find("Price").GetComponent<TextMeshPro>();

        price.text = item.price.ToString();
        
        image.sprite = S_ItemsAsset.instance.GetAsset(item.type, item.id);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnSlotCliked?.Invoke(this, EventArgs.Empty);
    }
}
