using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerSkill : MonoBehaviour
{
    [field: SerializeField] public List<SkillBase> skillBaseList {  get; private set; }
    [field: SerializeField] public List<SkillBaseSO> PlayerSkills { get; set; }



    [field: SerializeField] public PlayerAnimation PlayerAnimation { get; set; }

    [field:SerializeField] public Player Player { get; set; }

    public bool IsUsing { get; set; }
    public bool CanUse {  get; set; }

    public IPlayerSkillService PlayerSkillService {  get; set; }

    private void Awake()
    {
        PlayerSkillService = new PlayerSkillManager();
    }

    private void Start()
    {
        PlayerSkills = PlayerPrefsSavingSystem.GetList<SkillBaseSO>(PlayerPrefsSavingSystem.PlayerPrefsNameEnum.Skills);

        foreach (var playerSkill in PlayerSkills)
        {
            foreach (var skill in skillBaseList)
            {
                if (playerSkill == skill.SkillBaseSO)
                {
                    skill.CanUse = true;
                }
            }
        }

        foreach (SkillBase skillBase in skillBaseList)
        {
            skillBase.PlayerSkillStateService.Initialize(skillBase.PlayerSkillUseableState);
        }

        CanUse = true;
    }

    private void Update()
    {
        foreach (SkillBase skillBase in skillBaseList)
        {
            skillBase.PlayerSkillStateService.CurrentPlayerSkillState.UpdateState();
        }

    }

}
