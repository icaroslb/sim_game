using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Character : MonoBehaviour
{
    //Character Type
    [SerializeField] public S_Item.CharacterType type { get; private set; }

    // Clothes IDs
    [SerializeField] private int _idShirt;
    [SerializeField] private int _idShort;
    [SerializeField] private int _idShoes;

    // Clothes renderer
    [SerializeField] private SpriteRenderer spriteHair;
    [SerializeField] private SpriteRenderer spriteShirt;
    [SerializeField] private SpriteRenderer spriteShort;

    [SerializeField] private SpriteRenderer spriteRightShoe;
    [SerializeField] private SpriteRenderer spriteLeftShoe;

    [SerializeField] private SpriteRenderer spriteRightHand;
    [SerializeField] private SpriteRenderer spriteLeftHand;

    // Getters and Setters
    public int idShirt
    {
        get { return _idShirt; }
        set
        {
            _idShirt = value;
            UpdateSprite(spriteShirt, S_Item.ItemType.Shirt, _idShirt);
        }
    }
    public int idShort
    {
        get { return _idShort; }
        set
        {
            _idShort = value;
            UpdateSprite(spriteShort, S_Item.ItemType.Short, _idShort);
        }
    }
    public int idShoes
    {
        get { return _idShoes; }
        set
        {
            _idShoes = value;
            UpdateSprite(spriteRightShoe, S_Item.ItemType.RightShoe, _idShoes);
            UpdateSprite(spriteLeftShoe, S_Item.ItemType.LeftShoe, _idShoes);
        }
    }
    public void Initialize(S_IOCharacter data)
    {
        type = S_Item.CharacterType.Player;

        idShirt = data._idShirt;
        idShort = data._idShort;
        idShoes = data._idShoes;
    }
    public void Initialize(S_Item.CharacterType newType)
    {
        type = newType;
        
        int value = type.GetHashCode();

        idShirt = value;
        idShort = value;
        idShoes = value;
    }

    public void ChangeClothe (S_Item.ItemType itemType, int id)
    {
        switch (itemType)
        {
            case S_Item.ItemType.Shirt:
                idShirt = id;
                break;
            case S_Item.ItemType.Short:
                idShort = id;
                break;
            case S_Item.ItemType.Shoes:
                idShoes = id;
                break;
        }
    }

    private void UpdateSprite(SpriteRenderer spriteR, S_Item.ItemType itemType, int id)
    {
        if (type == S_Item.CharacterType.Player)
            spriteR.sprite = S_ItemsAsset.instance.GetAsset(itemType, id);
        else
            spriteR.sprite = S_ItemsAsset.instance.GetAssetNPC(itemType, id);
    }
}
