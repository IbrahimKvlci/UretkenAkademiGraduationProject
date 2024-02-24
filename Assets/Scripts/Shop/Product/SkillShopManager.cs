using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillShopManager : IProductShopService
{
    public void Buy(ProductSO productSO, Player player)
    {
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
}
