using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Shoes : S_Item_Data
{
    public enum Side
    {
        Left,
        Right
    }

    [SerializeField] private Sprite icon;

    [SerializeField] private Sprite UpRight;
    [SerializeField] private Sprite DownRight;
    [SerializeField] private Sprite RightRight;
    [SerializeField] private Sprite LeftRight;

    [SerializeField] private Sprite UpLeft;
    [SerializeField] private Sprite DownLeft;
    [SerializeField] private Sprite RightLeft;
    [SerializeField] private Sprite LeftLeft;

    public Sprite GetSprite(S_Item_Data.SpriteType type, S_Shoes.Side side = S_Shoes.Side.Right)
    {
        if (side == Side.Right)
        {
            switch (type)
            {
                case S_Item_Data.SpriteType.Up: return UpRight;
                case S_Item_Data.SpriteType.Down: return DownRight;
                case S_Item_Data.SpriteType.Left: return LeftRight;
                case S_Item_Data.SpriteType.Right: return RightRight;
            }
        }
        else
        {
            switch (type)
            {
                case S_Item_Data.SpriteType.Up: return UpLeft;
                case S_Item_Data.SpriteType.Down: return DownLeft;
                case S_Item_Data.SpriteType.Left: return LeftLeft;
                case S_Item_Data.SpriteType.Right: return RightLeft;
            }
        }

        return icon;
    }
}
