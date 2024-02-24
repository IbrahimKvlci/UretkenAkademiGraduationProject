using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : IShopService
{
    public void BuyProduct(ProductSO productSO, Player player)
    {
        Debug.Log(productSO);
        if (player.PlayerGoldService.Gold >= productSO.price)
        {
            //Gold is  enough
            player.PlayerGoldService.Gold -= productSO.price;

            productSO.ProductShopService.Buy(productSO, player);
        }
        else
        {
            //Not enough
        }
    }
}
