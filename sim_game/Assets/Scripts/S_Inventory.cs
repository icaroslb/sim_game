using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.VersionControl;
using UnityEngine;

public class S_Inventory
{
    private List<S_Item> _listItems;

    public List<S_Item> listItems { get { return _listItems; } }

    public S_Inventory ()
    {
        _listItems = new List<S_Item>();
        Debug.Log("Inventory");
    }

    public void AddItem (S_Item item)
    {
        _listItems.Add(item);
    }
}
