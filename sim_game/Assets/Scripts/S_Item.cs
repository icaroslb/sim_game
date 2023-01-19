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

    public enum CharacterType
    {
        Player = -1,
        Shopkeeper = 0
    }

    public ItemType _type;
    private int _id;
    private int _price;

    public ItemType type { get { return _type; } set { _type = value; } }
    public int id { get { return _id;} set { _id = value; } }
    public int price { get { return _price; } set { _price = value; } }
}
