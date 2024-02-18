using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillShopManager : IProductShopService
{
    public void Buy(ProductSO productSO, Player player)
    {
        if (player.Gold >= productSO.price)
        {
            //Gold is  enough
            player.Gold -=productSO.price;

            foreach (SkillBase skillBase in player.PlayerSkill.skillBaseList)
            {
                if (((SkillBaseSO)productSO) == skillBase.SkillBaseSO)
                {
                    skillBase.CanUse = true;
                }
            }
        }
        else
        {
            //Gold is not enough
        }

    }
}
