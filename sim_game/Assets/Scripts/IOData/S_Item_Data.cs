using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static S_Item;

// Main items data
public class S_Item_Data : MonoBehaviour
{
    // Type of sprites
    public enum SpriteType
    {
        Icon,
        Up,
        Down,
        Left,
        Right
    }
    
    // Main informations
    [SerializeField] protected ItemType type;
    [SerializeField] protected int id;
    [SerializeField] protected int price;

    // Getters
    public S_Item GetItem()
    {
        return new S_Item() { type = type, id = id, price = price };
    }

    public ItemType GetItemType()
    {
        return type;
    }

    public int GetId()
    {
        return id;
    }

    public int GetPrice()
    {
        return price;
    }
}
