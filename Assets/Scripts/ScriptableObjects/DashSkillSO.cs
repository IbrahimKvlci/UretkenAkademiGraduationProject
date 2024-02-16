using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class DashSkillSO : SkillBaseSO
{
    public float speed;

    public override void UseSkill()
    {
        if (SkillService == null)
        {
            SkillService=new DashSkillManager();
        }
        SkillService.UseSkill(this);
    }

}
