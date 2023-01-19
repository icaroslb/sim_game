using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class S_Pocket
{
    public int money { get; private set; }

    public event EventHandler OnPocketChange;

    public S_Pocket (int initialMoney)
    {
        money = initialMoney;
    }
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

    public void Sell (int value)
    {
        money += value;

        OnPocketChange?.Invoke(this, EventArgs.Empty);
    }
}
