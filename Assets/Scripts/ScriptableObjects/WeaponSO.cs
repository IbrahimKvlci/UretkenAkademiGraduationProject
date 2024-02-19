using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class WeaponSO : ProductSO
{
    public GameObject prefab;
    public int damage;
    public float speed;
    public float length;

    protected override void Buy()
    {
        base.Buy();
        Debug.Log("calisss");
        if (ProductShopService == null)
        {
            ProductShopService = new WeaponShopManager();
        }

        ProductShopService.Buy(this, Player.Instance);
    }
}
