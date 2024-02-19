using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dealer : MonoBehaviour, IInteractable
{
    public IDealerService DealerService { get; set; }
    public string Message { get; set; } = "Do you want to buy sth? (E)";

    private void Awake()
    {
        DealerService = new DealerManager();
    }

    public void Interact()
    {
        DealerService.Interact();
    }
}
