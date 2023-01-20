using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

// Clothing slot used on inventary. When clicked calls to change the clothing
public class S_ClothingSlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] public S_Item item { get; private set; }
    [SerializeField] private Image image;

    public event EventHandler OnSlotCliked;

    public void Initialize (S_Item newItem, EventHandler e)
    {
        item = newItem;
        OnSlotCliked += e;

        image.sprite = S_ItemsAsset.instance.GetSprite(item.type, S_Item_Data.SpriteType.Icon, item.id);
    }

    public void OnPointerClick (PointerEventData eventData)
    {
        OnSlotCliked?.Invoke(this, EventArgs.Empty);
    }
}
