using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Player : MonoBehaviour
{
    // Player informations
    [SerializeField] private string playerName;
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private S_Inventory inventory;

    [SerializeField] private S_Character character;
    [SerializeField] private S_UIInventory uiInventory;

    private void Awake()
    {
        inventory = new S_Inventory();
    }

    private void Start()
    {
        inventory.AddItem(new S_Item { type = S_Item.ItemType.Shirt, id = 0 });
        inventory.AddItem(new S_Item { type = S_Item.ItemType.Shirt, id = 1 });
        inventory.AddItem(new S_Item { type = S_Item.ItemType.Short, id = 0 });
        inventory.AddItem(new S_Item { type = S_Item.ItemType.Short, id = 1 });
        inventory.AddItem(new S_Item { type = S_Item.ItemType.RightShoe, id = 0 });
        inventory.AddItem(new S_Item { type = S_Item.ItemType.LeftShoe, id = 0 });

        uiInventory.insertInventory(inventory);
        uiInventory.UpdateInventory();

        character.UpdateData(S_IO.Load(name));
    }

    private void Update()
    {
        Vector3 direction = Vector3.zero;

        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        direction.Normalize();

        transform.position += direction * Time.deltaTime * speed;
    }
}
