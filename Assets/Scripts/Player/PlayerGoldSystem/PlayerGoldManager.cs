using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGoldManager : IPlayerGoldService
{
    public event EventHandler OnPlayerGoldChanged;

    private int _gold=500;
    public int Gold
    {
        get
        {
            return _gold;
        }
        set
        {
            _gold = value;
            OnPlayerGoldChanged?.Invoke(this, EventArgs.Empty);
        }
    }

    
}
