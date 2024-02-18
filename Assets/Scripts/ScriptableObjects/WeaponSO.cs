using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class WeaponSO : ProductSO
{
    public GameObject prefab;
    public float damage;
    public float speed;
    public float length;

    protected override void Buy()
    {
        base.Buy();
        Debug.Log("calisss");
        if (ProductShopService == null)
        {
            ProductShopService = new WeaponShopService();
        }

        ProductShopService.Buy(this, Player.Instance);
    }
}
