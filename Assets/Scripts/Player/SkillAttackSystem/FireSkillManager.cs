using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSkillManager:ISkillService
{
    public void UseSkill(SkillBaseSO fireSkillSO)
    {
        Debug.Log($"Used {((FireSkillSO)fireSkillSO).damage}");
    }
}
