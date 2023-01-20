using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class S_Store
{
    public event EventHandler OnStoreChange;

    // Lists to saves all the clothings ids
    public List<int> shirtsIds;
    public List<int> shortsIds;
    public List<int> shoesIds;

    public List<bool> isBoughtShirt;
    public List<bool> isBoughtShort;
    public List<bool> isBoughtShoes;

    public S_Store (List<int> newShirtsIds, List<int> newShortsIds, List<int> newShoesIds)
    {
        shirtsIds = newShirtsIds;
        shortsIds = newShortsIds;
        shoesIds = newShoesIds;

        isBoughtShirt = new List<bool>(shirtsIds.Count);
        isBoughtShort = new List<bool>(shortsIds.Count);
        isBoughtShoes = new List<bool>(shoesIds.Count);

        InitializeBoughtList(ref isBoughtShirt, shirtsIds.Count);
        InitializeBoughtList(ref isBoughtShort, shortsIds.Count);
        InitializeBoughtList(ref isBoughtShoes, shoesIds.Count);
    }

    // Initialize the bought list
    private void InitializeBoughtList (ref List<bool> boughtList, int size)
    {
        for (int i = 0; i < size; i++)
        {
            boughtList.Add(false);
        }
    }

    // Observer called when an item is boght
    public void BuyItem (object sender, EventArgs e)
    {
        S_StoreItemSlot itemBougth = sender as S_StoreItemSlot;
        int pos;
        
        switch (itemBougth.item.type)
        {
            case S_Item.ItemType.Shirt:
                pos = shirtsIds.Find(i => i == itemBougth.item.id);
                isBoughtShirt[pos] = true;
                break;
            case S_Item.ItemType.Short:
                pos = shortsIds.Find(i => i == itemBougth.item.id);
                isBoughtShort[pos] = true;
                break;
            case S_Item.ItemType.Shoes:
                pos = shoesIds.Find(i => i == itemBougth.item.id);
                isBoughtShoes[pos] = true;
                break;
        }

        OnStoreChange?.Invoke(this, EventArgs.Empty);
    }
    
    // Observer called when an item is sold
    public void SellItem(object sender, EventArgs e)
    {
        S_StoreItemSlot itemBougth = sender as S_StoreItemSlot;
        int pos;

        switch (itemBougth.item.type)
        {
            case S_Item.ItemType.Shirt:
                pos = shirtsIds.Find(i => i == itemBougth.item.id);
                isBoughtShirt[pos] = false;
                break;
            case S_Item.ItemType.Short:
                pos = shortsIds.Find(i => i == itemBougth.item.id);
                isBoughtShort[pos] = false;
                break;
            case S_Item.ItemType.Shoes:
                pos = shoesIds.Find(i => i == itemBougth.item.id);
                isBoughtShoes[pos] = false;
                break;
        }

        OnStoreChange?.Invoke(this, EventArgs.Empty);
    }
}
