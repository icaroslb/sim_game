using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.VersionControl;
using UnityEngine;

public class S_Inventory
{
    public event EventHandler OnInventoryChange;

    public List<S_Item> listItems { get; private set; }

    public S_Inventory ()
    {
        listItems = new List<S_Item>();
    }

    public void AddItem (S_Item item)
    {
        listItems.Add(item);
        OnInventoryChange?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveItem (S_Item item)
    {
        listItems.Remove(item);
        OnInventoryChange?.Invoke(this, EventArgs.Empty);
    }
}
