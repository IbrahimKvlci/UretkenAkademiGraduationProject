using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillShopService : IProductShopService
{
    public void Buy(ProductSO productSO, Player player)
    {
        Debug.Log($"Buy {((SkillBaseSO)productSO).price}");
    }
}
