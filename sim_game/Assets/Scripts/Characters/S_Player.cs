using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Player : MonoBehaviour
{
    // Player informations
    [SerializeField] private string playerName;
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private S_Inventory inventory;
    [SerializeField] private S_Pocket _pocket;

    [SerializeField] private S_Character character;
    [SerializeField] private S_UIInventory uiInventory;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform cameraPosition;

    [SerializeField] private Animator controller;
    [SerializeField] private int currentAnimation;
    [SerializeField] private Vector2 directionAnimation;

    public S_Pocket pocket { get { return _pocket; } private set { _pocket = value; } }

    private void Awake()
    {
        inventory = new S_Inventory();
        pocket = new S_Pocket(20);
        directionAnimation = Vector2.zero;
    }

    private void Start()
    {
        if (uiInventory != null)
            uiInventory.insertInventory(inventory);

        inventory.AddItem(new S_Item { type = S_Item.ItemType.Shirt, id = -1, price = 0 });
        inventory.AddItem(new S_Item { type = S_Item.ItemType.Short, id = -1, price = 0 });
        inventory.AddItem(new S_Item { type = S_Item.ItemType.Shoes, id = -1, price = 0 });

        character.Initialize();

        ChangeAnimation(S_Character.A_Idle_Down);
    }

    private void LateUpdate()
    {
        Vector3 direction = Vector3.zero;

        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        if (direction.x != 0f || direction.y != 0f)
        {
            direction.Normalize();

            rb.MovePosition(transform.position + direction * Time.fixedDeltaTime * speed);

            if (cameraPosition != null)
            {
                cameraPosition.position = transform.position + new Vector3(0f, 0f, -10f);
            }

            if (direction.y > 0f)
            {
                if (ChangeAnimation(S_Character.A_Run_Up))
                    directionAnimation = new Vector2(0f, 1f);
            }
            else if (direction.x > 0f)
            {
                if (ChangeAnimation(S_Character.A_Run_Right))
                    directionAnimation = new Vector2(1f, 0f);
            }
            else if (direction.x < 0f)
            {
                if (ChangeAnimation(S_Character.A_Run_Left))
                    directionAnimation = new Vector2(-1f, 0f);
            }
            else
            {
                if (ChangeAnimation(S_Character.A_Run_Down))
                    directionAnimation = new Vector2(0f, -1f);
            }
        }
        else
        {
            if (directionAnimation.y > 0f)
                ChangeAnimation(S_Character.A_Idle_Up);
            else if (directionAnimation.x > 0f)
                ChangeAnimation(S_Character.A_Idle_Right);
            else if (directionAnimation.x < 0f)
                ChangeAnimation(S_Character.A_Idle_Left);
            else
                ChangeAnimation(S_Character.A_Idle_Down);
        }
    }

    public bool Buy (S_Item item)
    {
        bool canBuy = pocket.Buy(item.price);

        if (canBuy)
        {
            inventory.AddItem(item);
            return true;
        }

        return false;
    }

    public void Sell (S_Item item)
    {
        pocket.Sell(item.price);
        inventory.RemoveItem(item);

        if (character.IsUsing(item))
        {
            character.ChangeClothe(item.type, -1);
        }
    }

    private bool ChangeAnimation (int newAnimation)
    {
        if (currentAnimation == newAnimation)
            return false;

        controller.Play(newAnimation);
        currentAnimation = newAnimation;

        character.UpdateSpriteType(newAnimation);

        return true;
    }
}
