using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static S_Item;
using static S_Item_Data;
using static S_Shoes;

public class S_ItemsAsset : MonoBehaviour
{
    public static S_ItemsAsset instance { get; private set; }


    [SerializeField] private S_Clothe shirtDefault;
    [SerializeField] private S_Clothe shortDefault;
    [SerializeField] private S_Shoes  shoesDefault;

    [SerializeField] private List<S_Clothe> shirts;
    [SerializeField] private List<S_Clothe> shorts;
    [SerializeField] private List<S_Shoes>  shoes;

    [SerializeField] private List<S_Clothe> shirtsNPC;
    [SerializeField] private List<S_Clothe> shortsNPC;
    [SerializeField] private List<S_Shoes> shoesNPC;

    private void Awake()
    {
        instance = this;

        shirtDefault = Resources.Load<S_Clothe>("Default/ShirtDefault");
        shortDefault = Resources.Load<S_Clothe>("Default/ShortDefault");
        shoesDefault = Resources.Load<S_Shoes>("Default/ShoesDefault");

        shirts = Resources.LoadAll<S_Clothe>("Shirts").ToList<S_Clothe>();
        shorts = Resources.LoadAll<S_Clothe>("Shorts").ToList<S_Clothe>();
        shoes = Resources.LoadAll<S_Shoes>("Shoes").ToList<S_Shoes>();

        shirtsNPC = Resources.LoadAll<S_Clothe>("NPC/Shirts").ToList<S_Clothe>();
        shortsNPC = Resources.LoadAll<S_Clothe>("NPC/Shorts").ToList<S_Clothe>();
        shoesNPC = Resources.LoadAll<S_Shoes>("NPC/Shoes").ToList<S_Shoes>();
    }

    public int Getprice (ItemType itemType, int id)
    {
        int priceReturn = 0;

        switch (itemType)
        {
            case ItemType.Shirt:
                priceReturn = shirts[id].GetPrice();
                break;
            case ItemType.Short:
                priceReturn = shorts[id].GetPrice();
                break;
            case ItemType.Shoes:
                priceReturn = shoes[id].GetPrice();
                break;
        }

        return priceReturn;
    }

    public S_Item GetAsset (ItemType itemType, int id)
    {
        S_Item assetReturn = null;

        switch (itemType)
        {
            case ItemType.Shirt:
                assetReturn = shirts[id].GetItem();
                break;
            case ItemType.Short:
                assetReturn = shorts[id].GetItem();
                break;
            case ItemType.Shoes:
                assetReturn = shoes[id].GetItem();
                break;
        }

        return assetReturn;
    }

    public Sprite GetSprite (ItemType itemType, S_Item_Data.SpriteType spriteType, int id, S_Shoes.Side side = S_Shoes.Side.Right)
    {
        Sprite spriteReturn = null;

        if (id < 0)
        {
            switch (itemType)
            {
                case ItemType.Shirt:
                    spriteReturn = shirtDefault.GetSprite(spriteType);
                    break;
                case ItemType.Short:
                    spriteReturn = shortDefault.GetSprite(spriteType);
                    break;
                case ItemType.Shoes:
                    spriteReturn = shoesDefault.GetSprite(spriteType, side);
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
                    spriteReturn = shirts[id].GetSprite(spriteType);
                    break;
                case ItemType.Short:
                    spriteReturn = shorts[id].GetSprite(spriteType);
                    break;
                case ItemType.Shoes:
                    spriteReturn = shoes[id].GetSprite(spriteType, side);
                    break;
            }
        }

        return spriteReturn;
    }

    public Sprite GetAssetNPC(ItemType itemType, S_Item_Data.SpriteType spriteType, int id, S_Shoes.Side side = S_Shoes.Side.Right)
    {
        Sprite spriteReturn = null;

        switch (itemType)
        {
            case ItemType.Shirt:
                spriteReturn = shirtsNPC[id].GetSprite(spriteType);
                break;
            case ItemType.Short:
                spriteReturn = shortsNPC[id].GetSprite(spriteType);
                break;
            case ItemType.Shoes:
                spriteReturn = shoesNPC[id].GetSprite(spriteType, side);
                break;
            default:
                spriteReturn = GetSprite(itemType, spriteType, id, side);
                break;
        }

        return spriteReturn;
    }

    public int GetQtdShirts()
    {
        return shirts.Count;
    }

    public int GetQtdShorts()
    {
        return shorts.Count;
    }

    public int GetQtdShoes()
    {
        return shoes.Count;
    }
}
