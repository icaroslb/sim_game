using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static S_Item;

public class S_ItemsAsset : MonoBehaviour
{
    public static S_ItemsAsset instance { get; private set; }

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] public List<Sprite> shirtSprites;
    [SerializeField] public List<Sprite> shortsSprites;
    [SerializeField] public List<Sprite> rightShoeSprites;
    [SerializeField] public List<Sprite> leftShoeSprites;

    public Sprite GetAsset (ItemType itemType, int id)
    {
        Sprite spriteReturn = null;

        switch (itemType)
        {
            case ItemType.Shirt:
                spriteReturn = shirtSprites[id];
                break;
            case ItemType.Short:
                spriteReturn = shortsSprites[id];
                break;
            case ItemType.RightShoe:
                spriteReturn = rightShoeSprites[id];
                break;
            case ItemType.LeftShoe:
                spriteReturn = leftShoeSprites[id];
                break;
        }

        return spriteReturn;
    }
}
