using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; set; }

    [field:SerializeField] public PlayerSO PlayerSO { get; private set; }

    public IPlayerHealthService PlayerHealthService {  get; private set; }


    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There are more than one player");
        }

        Instance = this;

        PlayerHealthService = new PlayerHealthManager();
    }

    private void Start()
    {
        PlayerHealthService.Health = PlayerSO.maxHealth;
    }


}
