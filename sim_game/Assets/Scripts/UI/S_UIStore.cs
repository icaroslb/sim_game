using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using static UnityEditor.Progress;

public class S_UIStore : MonoBehaviour
{
    [SerializeField] S_Store _store;
    [SerializeField] private Transform _itemSlotContainer;
    [SerializeField] private Transform _itemSlot;


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
        _store.OnStoreChange += OnStoreChange;

        UpdateStore();
    }

    private void OnStoreChange(object sender, EventArgs e)
    {
        UpdateStore();
    }

    private void UpdateStore ()
    {
        foreach (Transform child in _itemSlotContainer)
        {
            Destroy(child.gameObject);
        }

        InitializeItemSlots(_store.shirtsIds, _store.isBoughtShirt, S_Item.ItemType.Shirt);
        InitializeItemSlots(_store.shortsIds, _store.isBoughtShort, S_Item.ItemType.Short);
        InitializeItemSlots(_store.shoesIds, _store.isBoughtShoes, S_Item.ItemType.Shoes);
    }

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
