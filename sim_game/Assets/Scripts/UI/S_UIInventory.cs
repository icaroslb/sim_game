using System;
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

    public void insertInventory (S_Inventory inventory)
    {
        _inventory = inventory;
        inventory.OnInventoryChange += OnInventoryChange;
    }

    private void OnInventoryChange (object sender, EventArgs e)
    {
        UpdateInventory();
    }

    private void UpdateInventory ()
    {
        foreach (Transform child in _clothesSlotContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (S_Item item in _inventory.listItems)
        {
            Transform newInstance = Instantiate(_clotheSlot, _clothesSlotContainer);
            S_ClotheSlot newClotheSlot = newInstance.GetComponent<S_ClotheSlot>();
            RectTransform newItem = newInstance.GetComponent<RectTransform>();

            newClotheSlot.Initialize(item, GameManager.instance.OnChangeClothes);
        }
    }
}
