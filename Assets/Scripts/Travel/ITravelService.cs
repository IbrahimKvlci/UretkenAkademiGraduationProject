using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITravelService
{
    event EventHandler OnTravelInteract;

    void Interact();
}
