using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillShopManager : IProductShopService
{
    public void Buy(ProductSO productSO, Player player)
    {
        if (player.PlayerGoldService.Gold >= productSO.price)
        {
            //Gold is  enough
            player.PlayerGoldService.Gold -= productSO.price;

            foreach (SkillBase skillBase in player.PlayerSkill.skillBaseList)
            {
                if (((SkillBaseSO)productSO) == skillBase.SkillBaseSO)
                {
                    skillBase.CanUse = true;
                    player.PlayerSkill.PlayerSkills.Add(skillBase);

                    PlayerPrefsSavingSystem.SetList<SkillBase>(PlayerPrefsSavingSystem.PlayerPrefsNameEnum.Skills, player.PlayerSkill.PlayerSkills);
                }
            }
        }
        else
        {
            //Gold is not enough
        }

    }
}
