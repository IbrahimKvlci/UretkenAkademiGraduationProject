using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Travel : MonoBehaviour, IInteractable
{
    public string Message { get; set; } = "Are you leaving this map?";

    public ITravelService TravelService {  get; private set; }

    private void Awake()
    {
        TravelService = new TravelManager();
    }

    public void Interact()
    {
        TravelService.Interact();
    }
}
