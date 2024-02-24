using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapShopManager : IProductShopService
{
    public void Buy(ProductSO productSO, Player player)
    {
        Loader.Load(((MapSO)productSO).Map);
    }

}
