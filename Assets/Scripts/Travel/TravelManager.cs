using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelManager : ITravelService
{
    public event EventHandler OnTravelInteract;

    public void Interact()
    {
        OnTravelInteract?.Invoke(this, EventArgs.Empty);
    }
}
