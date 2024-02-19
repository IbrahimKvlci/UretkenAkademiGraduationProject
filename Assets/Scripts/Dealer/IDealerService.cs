using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDealerService
{
    event EventHandler OnInteract;

    void Interact();
}
