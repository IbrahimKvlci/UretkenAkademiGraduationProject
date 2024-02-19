using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerGoldService
{
    event EventHandler OnPlayerGoldChanged;

    public int Gold { get; set; }
}
