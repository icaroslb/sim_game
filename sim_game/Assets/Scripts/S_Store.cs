using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class S_Store
{
    public event EventHandler OnStoreChange;

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

        isBoughtShirt.ForEach(i => { i = false; });
        isBoughtShort.ForEach(i => { i = false; });
        isBoughtShoes.ForEach(i => { i = false; });
    }

    //public void BuyItem (int id)
    //{
    //    int pos = items.Find(i => i == id);
    //    isBought[pos] = false;
    //
    //    OnStoreChange?.Invoke(this, EventArgs.Empty);
    //}
    //
    //public void SellItem(int id)
    //{
    //    int pos = items.Find(i => i == id);
    //    isBought[pos] = true;
    //
    //    OnStoreChange?.Invoke(this, EventArgs.Empty);
    //}
}
