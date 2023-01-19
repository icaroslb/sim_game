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

    [SerializeField] public List<Sprite> shirtsSprites;
    [SerializeField] public List<int> shirtsPrices;

    [SerializeField] public List<Sprite> shortsSprites;
    [SerializeField] public List<int> shortsPrices;

    [SerializeField] public List<Sprite> ShoesSprites;
    [SerializeField] public List<int> ShoesPrices;

    [SerializeField] public List<Sprite> rightShoeSprites;
    [SerializeField] public List<Sprite> leftShoeSprites;

    [SerializeField] public List<Sprite> shirtSpritesNPC;
    [SerializeField] public List<Sprite> shortsSpritesNPC;
    [SerializeField] public List<Sprite> rightShoeSpritesNPC;
    [SerializeField] public List<Sprite> leftShoeSpritesNPC;

    public int Getprice (ItemType itemType, int id)
    {
        int priceReturn = 0;

        switch (itemType)
        {
            case ItemType.Shirt:
                priceReturn = shirtsPrices[id];
                break;
            case ItemType.Short:
                priceReturn = shortsPrices[id];
                break;
            case ItemType.Shoes:
                priceReturn = ShoesPrices[id];
                break;
        }

        return priceReturn;
    }

    public Sprite GetAsset (ItemType itemType, int id)
    {
        Sprite spriteReturn = null;

        switch (itemType)
        {
            case ItemType.Shirt:
                spriteReturn = shirtsSprites[id];
                break;
            case ItemType.Short:
                spriteReturn = shortsSprites[id];
                break;
            case ItemType.Shoes:
                spriteReturn = ShoesSprites[id];
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

    public Sprite GetAssetNPC(ItemType itemType, int id)
    {
        Sprite spriteReturn = null;

        switch (itemType)
        {
            case ItemType.Shirt:
                spriteReturn = shirtSpritesNPC[id];
                break;
            case ItemType.Short:
                spriteReturn = shortsSpritesNPC[id];
                break;
            case ItemType.RightShoe:
                spriteReturn = rightShoeSpritesNPC[id];
                break;
            case ItemType.LeftShoe:
                spriteReturn = leftShoeSpritesNPC[id];
                break;
            default:
                spriteReturn = GetAsset(itemType, id);
                break;
        }

        return spriteReturn;
    }
}
