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

    [SerializeField] private Sprite shirtDefault;
    [SerializeField] private Sprite shortDefault;
    [SerializeField] private Sprite shoesDefault;

    [SerializeField] private List<Sprite> shirtsSprites;
    [SerializeField] private List<int> shirtsPrices;

    [SerializeField] private List<Sprite> shortsSprites;
    [SerializeField] private List<int> shortsPrices;

    [SerializeField] private List<Sprite> ShoesSprites;
    [SerializeField] private List<int> ShoesPrices;

    [SerializeField] private List<Sprite> rightShoeSprites;
    [SerializeField] private List<Sprite> leftShoeSprites;

    [SerializeField] private List<Sprite> shirtSpritesNPC;
    [SerializeField] private List<Sprite> shortsSpritesNPC;
    [SerializeField] private List<Sprite> rightShoeSpritesNPC;
    [SerializeField] private List<Sprite> leftShoeSpritesNPC;

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

        if (id < 0)
        {
            switch (itemType)
            {
                case ItemType.Shirt:
                    spriteReturn = shirtDefault;
                    break;
                case ItemType.Short:
                    spriteReturn = shortDefault;
                    break;
                case ItemType.Shoes:
                    spriteReturn = shoesDefault;
                    break;
                default:
                    spriteReturn = null;
                    break;
            }
        }
        else
        {
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

    public int GetQtdShirts()
    {
        return shirtsSprites.Count;
    }

    public int GetQtdShorts()
    {
        return shortsSprites.Count;
    }

    public int GetQtdShoes()
    {
        return ShoesSprites.Count;
    }
}
