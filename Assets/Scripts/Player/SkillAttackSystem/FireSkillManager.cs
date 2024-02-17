using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSkillManager:ISkillService
{
    public event EventHandler OnSkillUsed;

    public void UseSkill(SkillBaseSO fireSkillSO)
    {
        OnSkillUsed?.Invoke(this, EventArgs.Empty);
        Debug.Log($"Used {((FireSkillSO)fireSkillSO).damage}");
    }
}
