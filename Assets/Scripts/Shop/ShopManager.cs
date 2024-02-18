using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : IShopService
{
    public void BuyProduct(ProductSO productSO, Player player)
    {
        productSO.ProductShopService.Buy(productSO, player);
    }
}
