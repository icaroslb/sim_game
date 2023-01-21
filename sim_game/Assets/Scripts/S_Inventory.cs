using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class to inventory
public class S_Inventory
{
    public event EventHandler OnInventoryChange;

    public List<S_Item> listItems { get; private set; }

    public S_Inventory ()
    {
        listItems = new List<S_Item>();
    }

    // Adds an item in Inventory
    public void AddItem (S_Item item)
    {
        listItems.Add(item);
        OnInventoryChange?.Invoke(this, EventArgs.Empty);
    }

    // Removes an item in inventory
    public void RemoveItem (S_Item item)
    {
        listItems.Remove(item);
        OnInventoryChange?.Invoke(this, EventArgs.Empty);
    }
}
