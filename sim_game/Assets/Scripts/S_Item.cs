using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Item
{
    public enum ItemType
    {
        Shirt,
        Short,
        Shoes,
        RightShoe,
        LeftShoe
    }

    private ItemType _type;
    private int _id;

    public ItemType type { get { return _type; } set { _type = value; } }
    public int id { get { return _id;} set { _id = value; } }
}
