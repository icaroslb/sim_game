using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static S_Item;
using static S_Shoes;

public class S_Character : MonoBehaviour
{
    // Encapsulate the character clothes informations
    public class CharacterData
    {
        public int idShirt = -1;
        public int idShort = -1;
        public int idShoes = -1;
    }

    // Hash number of each character animation
    public static int A_Idle_Down  = Animator.StringToHash("CharacterIdleDown");
    public static int A_Idle_Up    = Animator.StringToHash("CharacterIdleUp");
    public static int A_Idle_Left  = Animator.StringToHash("CharacterIdleLeft");
    public static int A_Idle_Right = Animator.StringToHash("CharacterIdleRight");

    public static int A_Run_Down  = Animator.StringToHash("CharacterRunDown");
    public static int A_Run_Up    = Animator.StringToHash("CharacterRunUp");
    public static int A_Run_Left  = Animator.StringToHash("CharacterRunLeft");
    public static int A_Run_Right = Animator.StringToHash("CharacterRunRight");

    //Character Type
    [SerializeField] public S_Item.CharacterType type { get; private set; }

    // Clothes IDs
    [SerializeField] private int _idShirt;
    [SerializeField] private int _idShort;
    [SerializeField] private int _idShoes;

    // Clothes renderer
    [SerializeField] private SpriteRenderer spriteShirt;
    [SerializeField] private SpriteRenderer spriteShort;

    [SerializeField] private SpriteRenderer spriteRightShoe;
    [SerializeField] private SpriteRenderer spriteLeftShoe;

    [SerializeField] private S_Item_Data.SpriteType spriteType;

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
            UpdateSprite(spriteRightShoe, S_Item.ItemType.Shoes, _idShoes, S_Shoes.Side.Right);
            UpdateSprite(spriteLeftShoe, S_Item.ItemType.Shoes, _idShoes, S_Shoes.Side.Left);
        }
    }

    // Initialization functions
    public void Initialize()
    {
        Initialize(new S_Character.CharacterData() { idShirt = -1, idShort = -1, idShoes = -1 });
    }
    public void Initialize(S_Character.CharacterData data, S_Item_Data.SpriteType newSpriteType = S_Item_Data.SpriteType.Down)
    {
        spriteType = newSpriteType;
        type = S_Item.CharacterType.Player;

        GameManager.instance.ChangeClothes += OnChangeClothes;

        idShirt = data.idShirt;
        idShort = data.idShort;
        idShoes = data.idShoes;
    }


    public void Initialize(S_Item.CharacterType newType, S_Item_Data.SpriteType newSpriteType = S_Item_Data.SpriteType.Down)
    {
        spriteType = newSpriteType;
        type = newType;
        
        int value = type.GetHashCode();

        idShirt = value;
        idShort = value;
        idShoes = value;
    }

    // Verify if the character is using a specific clothing
    public bool IsUsing (S_Item item)
    {
        switch (item.type)
        {
            case S_Item.ItemType.Shirt:
                return _idShirt == item.id;
            case S_Item.ItemType.Short:
                return _idShort == item.id;
            case S_Item.ItemType.Shoes:
                return _idShoes == item.id;
        }

        return false;
    }

    // Obeserver called when a clothing is changing
    public void OnChangeClothes (object sender, EventArgs e)
    {
        S_ClothingSlot clotheSlot = sender as S_ClothingSlot;

        ChangeClothe(clotheSlot.item.type, clotheSlot.item.id);
    }

    // Function to change a clothing
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

    // Update all the clothes
    private void TotalUpdate ()
    {
        UpdateSprite(spriteShirt, S_Item.ItemType.Shirt, _idShirt);
        UpdateSprite(spriteShort, S_Item.ItemType.Short, _idShort);

        UpdateSprite(spriteRightShoe, S_Item.ItemType.Shoes, _idShoes, S_Shoes.Side.Right);
        UpdateSprite(spriteLeftShoe, S_Item.ItemType.Shoes, _idShoes, S_Shoes.Side.Left);
    }

    // Update the clothing sprite
    private void UpdateSprite(SpriteRenderer spriteR, S_Item.ItemType itemType, int id, S_Shoes.Side side = S_Shoes.Side.Right)
    {
        if (type == S_Item.CharacterType.Player)
            spriteR.sprite = S_ItemsAsset.instance.GetSprite(itemType, this.spriteType, id, side);
        else
            spriteR.sprite = S_ItemsAsset.instance.GetSpriteNPC(itemType, this.spriteType, id, side);
    }

    // Change the sprite to the correc direction
    public void UpdateSpriteType (int direction)
    {
        if (direction == A_Idle_Down || direction == A_Run_Down)
        {
            spriteType = S_Item_Data.SpriteType.Down;
        }
        else if (direction == A_Idle_Up || direction == A_Run_Up)
        {
            spriteType = S_Item_Data.SpriteType.Up;
        }
        else if (direction == A_Idle_Left || direction == A_Run_Left)
        {
            spriteType = S_Item_Data.SpriteType.Left;
        }
        else
        {
            spriteType = S_Item_Data.SpriteType.Right;
        }

        TotalUpdate();
    }
}
