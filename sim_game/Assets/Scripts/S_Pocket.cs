using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// Pocket class
public class S_Pocket
{
    public int money { get; private set; }

    // Observer that call when the money value changed
    public event EventHandler OnPocketChange;

    public S_Pocket (int initialMoney)
    {
        money = initialMoney;
    }

    // Verify if is possible buy something
    public bool Buy (int value)
    {
        if (money >= value)
        {
            money -= value;
            OnPocketChange?.Invoke(this, EventArgs.Empty);

            return true;
        }
        else
        {
            return false;
        }
    }

    // Adds value gained
    public void Sell (int value)
    {
        money += value;

        OnPocketChange?.Invoke(this, EventArgs.Empty);
    }
}
