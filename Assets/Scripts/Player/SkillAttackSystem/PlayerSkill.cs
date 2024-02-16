using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerSkill : MonoBehaviour
{
    [field: SerializeField] public SkillBase FireSkill { get; set; }
    [field: SerializeField] public SkillBase DashSkill { get; set; }


    [field:SerializeField] public Player Player { get; set; }

    public IPlayerSkillService PlayerSkillService {  get; set; }

    private void Awake()
    {
        PlayerSkillService = new PlayerSkillManager();
    }

    private void Start()
    {
        FireSkill.PlayerSkillStateService.Initialize(FireSkill.PlayerSkillUseableState);
        DashSkill.PlayerSkillStateService.Initialize(DashSkill.PlayerSkillUseableState);

    }

    private void Update()
    {
        FireSkill.PlayerSkillStateService.CurrentPlayerSkillState.UpdateState();
        DashSkill.PlayerSkillStateService.CurrentPlayerSkillState.UpdateState();

    }

}
