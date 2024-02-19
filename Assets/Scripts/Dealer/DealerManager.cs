using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealerManager : IDealerService
{
    public event EventHandler OnInteract;

    public void Interact()
    {
        OnInteract?.Invoke(this, EventArgs.Empty);
    }
}
