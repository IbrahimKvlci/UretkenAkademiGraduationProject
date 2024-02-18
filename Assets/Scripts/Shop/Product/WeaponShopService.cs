using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShopService : IProductShopService
{
    public void Buy(ProductSO productSO, Player player)
    {
        Debug.Log($"Buy {((WeaponSO)productSO).price}");
    }
}
