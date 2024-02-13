using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There are more than one player");
        }

        Instance = this;
    }
}
