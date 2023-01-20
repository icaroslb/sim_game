using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static S_Item;

// Controls the UI inventory, updating the clothing slots.
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
        // Destroy all clothing slots
        foreach (Transform child in _clothesSlotContainer)
        {
            Destroy(child.gameObject);
        }

        // Create new ones
        foreach (S_Item item in _inventory.listItems)
        {
            Transform newInstance = Instantiate(_clotheSlot, _clothesSlotContainer);
            S_ClothingSlot newClotheSlot = newInstance.GetComponent<S_ClothingSlot>();
            RectTransform newItem = newInstance.GetComponent<RectTransform>();

            newClotheSlot.Initialize(item, GameManager.instance.OnChangeClothes);
        }
    }
}
