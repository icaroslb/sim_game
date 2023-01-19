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

    [SerializeField] private int qtdItemLine;

    [SerializeField] private float itemSize;
    [SerializeField] private float borderSizeWidth;
    [SerializeField] private float borderSizeHeight;

    void Start()
    {
        int qtdShirts = S_ItemsAsset.instance.shirtsSprites.Count;
        int qtdShorts = S_ItemsAsset.instance.shortsSprites.Count;
        int qtdShoes = S_ItemsAsset.instance.ShoesSprites.Count;


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

        int x = 0;
        int y = 0;

        float sizeItemWidth = itemSize + borderSizeWidth;
        float sizeItemHeight = itemSize + borderSizeHeight;

        InitializeItemSlots(_store.shirtsIds, S_Item.ItemType.Shirt, ref x, ref y, sizeItemWidth, sizeItemHeight);
        InitializeItemSlots(_store.shortsIds, S_Item.ItemType.Short, ref x, ref y, sizeItemWidth, sizeItemHeight);
        InitializeItemSlots(_store.shoesIds, S_Item.ItemType.Shoes, ref x, ref y, sizeItemWidth, sizeItemHeight);
    }

    private void InitializeItemSlots (in List<int> listIds, S_Item.ItemType typeItem, ref int x, ref int y, float sizeItemWidth, float sizeItemHeight)
    {
        foreach (int item in listIds)
        {
            Transform newInstance = Instantiate(_itemSlot, _itemSlotContainer);
            S_StoreItemSlot newItemSlot = newInstance.GetComponent<S_StoreItemSlot>();
            RectTransform newItem = newInstance.GetComponent<RectTransform>();

            newItemSlot.Initialize(new S_Item { id = item, type = typeItem, price = S_ItemsAsset.instance.Getprice(typeItem, item) }, null);
            newItem.anchoredPosition = new Vector2(x * sizeItemWidth, -y * sizeItemHeight);

            x++;

            if (x >= qtdItemLine)
            {
                x = 0;
                y++;
            }
        }
    }
}
