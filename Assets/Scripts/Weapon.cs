using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private List<WeaponSO> weapons;

    private void Awake()
    {
        foreach (var item in weapons)
        {
            item.ProductShopService = new WeaponShopService();
        }
    }
}
