using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class FireSkillSO : SkillBaseSO
{
    public GameObject prefab;
    public int damage;
    public float range;

    public override void UseSkill()
    {
        SkillService.UseSkill(this);
    }
}
