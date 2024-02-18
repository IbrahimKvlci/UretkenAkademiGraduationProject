using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private IShopService shopService;

    private void Awake()
    {
        shopService = new ShopManager();
    }

    public void BuyButton(ProductSO productSO)
    {
        shopService.BuyProduct(productSO, Player.Instance);
    }
}
