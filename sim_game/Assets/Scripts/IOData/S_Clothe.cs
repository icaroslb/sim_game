using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Clothe : S_Item_Data
{
    [SerializeField] private Sprite icon;
    [SerializeField] private Sprite Up;
    [SerializeField] private Sprite Down;
    [SerializeField] private Sprite Right;
    [SerializeField] private Sprite Left;

    public Sprite GetSprite (S_Item_Data.SpriteType type)
    {
        switch (type)
        {
            case S_Item_Data.SpriteType.Up: return Up;
            case S_Item_Data.SpriteType.Down: return Down;
            case S_Item_Data.SpriteType.Left: return Left;
            case S_Item_Data.SpriteType.Right: return Right;
            default: return icon;
        }
    }
}
