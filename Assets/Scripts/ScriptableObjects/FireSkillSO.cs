using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class FireSkillSO : SkillBaseSO
{
    public GameObject prefab;
    public float damage;
    public float range;

    public override void UseSkill(Player player)
    {
        if (SkillService == null)
        {
            SkillService=new FireSkillManager();
        }
        SkillService.UseSkill(this, player);
    }
}
