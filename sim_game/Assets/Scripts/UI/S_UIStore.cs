using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

// Controls the UI store, updating all the store item slots.
public class S_UIStore : MonoBehaviour
{
    [SerializeField] S_Store _store;
    [SerializeField] private Transform _itemSlotContainer;
    [SerializeField] private Transform _itemSlot;


    private void Awake()
    {
        _itemSlotContainer = GameObject.Find("StoreItemSlotContainer").transform;
    }

    void Start()
    {
        int qtdShirts = S_ItemsAsset.instance.GetQtdShirts();
        int qtdShorts = S_ItemsAsset.instance.GetQtdShorts();
        int qtdShoes = S_ItemsAsset.instance.GetQtdShoes();


        List<int> shirtsId = new List<int>(qtdShirts);
        List<int> shortsId = new List<int>(qtdShorts);
        List<int> shoesId = new List<int>(qtdShoes);

        for (int i = 0; i < qtdShirts; i++) shirtsId.Add(i);
        for (int i = 0; i < qtdShorts; i++) shortsId.Add(i);
        for (int i = 0; i < qtdShoes; i++) shoesId.Add(i);

        _store = new S_Store(shirtsId, shortsId, shoesId);

        UpdateStore();
    }

    private void OnStoreChange(object sender, EventArgs e)
    {
        UpdateStore();
    }

    private void UpdateStore ()
    {
        // Destroy all store item slots
        foreach (Transform child in _itemSlotContainer)
        {
            Destroy(child.gameObject);
        }

        // Create new ones
        InitializeItemSlots(_store.shirtsIds, _store.isBoughtShirt, S_Item.ItemType.Shirt);
        InitializeItemSlots(_store.shortsIds, _store.isBoughtShort, S_Item.ItemType.Short);
        InitializeItemSlots(_store.shoesIds, _store.isBoughtShoes, S_Item.ItemType.Shoes);
    }

    // Initialize a list of store item slots
    private void InitializeItemSlots (in List<int> listIds, in List<bool> listIdsSold, S_Item.ItemType typeItem)
    {
        int i = 0;

        foreach (int item in listIds)
        {
            Transform newInstance = Instantiate(_itemSlot, _itemSlotContainer);
            S_StoreItemSlot newItemSlot = newInstance.GetComponent<S_StoreItemSlot>();
            RectTransform newItem = newInstance.GetComponent<RectTransform>();

            newItemSlot.Initialize(
                S_ItemsAsset.instance.GetAsset(typeItem, item),
                listIdsSold[i],
                GameManager.instance.OnItemBuySell,
                _store.BuyItem,
                _store.SellItem
                );
            
            i++;
        }
    }
}
