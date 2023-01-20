using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class S_ClotheSlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] public S_Item item { get; private set; }

    public event EventHandler OnSlotCliked;

    public void Initialize (S_Item newItem, EventHandler e)
    {
        item = newItem;
        OnSlotCliked += e;

        Image image = transform.Find("Image").GetComponent<Image>();
        image.sprite = S_ItemsAsset.instance.GetAsset(item.type, S_Item_Data.SpriteType.Icon, item.id);
    }

    public void OnPointerClick (PointerEventData eventData)
    {
        OnSlotCliked?.Invoke(this, EventArgs.Empty);
    }
}
