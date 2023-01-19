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
    [SerializeField] private TextMeshProUGUI action;
    [SerializeField] private TextMeshProUGUI price;
    [SerializeField] public bool isSold { get; private set; }

    public event EventHandler OnSlotCliked;
    public event EventHandler OnBuy;
    public event EventHandler OnSell;


    public void Initialize(S_Item newItem, bool itemIsSold, EventHandler eClick, EventHandler eBuy, EventHandler eSell)
    {
        item = newItem;
        OnSlotCliked += eClick;
        OnBuy += eBuy;
        OnSell += eSell;

        isSold = itemIsSold;
        
        image.sprite = S_ItemsAsset.instance.GetAsset(item.type, item.id);

        price.text = item.price.ToString();

        if (!isSold)
        {
            action.text = "Buy";
            action.color = Color.green;
        }
        else
        {
            action.text = "Sell";
            action.color = Color.red;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnSlotCliked?.Invoke(this, EventArgs.Empty);
    }

    public void Buy ()
    {
            OnBuy?.Invoke(this, EventArgs.Empty);
    }

    public void Sell ()
    {
            OnSell?.Invoke(this, EventArgs.Empty);
    }
}
