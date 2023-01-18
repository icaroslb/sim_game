using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static S_Item;

public class S_UIInventory : MonoBehaviour
{
    [SerializeField] private S_Inventory _inventory;
    [SerializeField] private Transform _clothesSlotContainer;
    [SerializeField] private Transform _clotheSlot;

    [SerializeField] private int qtdItemLine;

    [SerializeField] private float itemSize;
    [SerializeField] private float borderSizeWidth;
    [SerializeField] private float borderSizeHeight;

    public void insertInventory (S_Inventory inventory)
    {
        _inventory = inventory;
        UpdateInventory();
    }

    private void UpdateInventory ()
    {
        int x = 0;
        int y = 0;

        float sizeItemWidth = itemSize + borderSizeWidth;
        float sizeItemHeight = itemSize + borderSizeHeight;

        foreach (S_Item item in _inventory.listItems)
        {
            RectTransform newItem = Instantiate(_clotheSlot, _clothesSlotContainer).GetComponent<RectTransform>();
            newItem.anchoredPosition = new Vector2(x * sizeItemWidth, -y * sizeItemHeight);
            
            Image image = newItem.Find("Image").GetComponent<Image>();
            image.sprite = S_ItemsAsset.instance.GetAsset(item.type, item.id);

            x++;

            if (x >= qtdItemLine)
            {
                x = 0;
                y++;
            }
        }
    }
}
