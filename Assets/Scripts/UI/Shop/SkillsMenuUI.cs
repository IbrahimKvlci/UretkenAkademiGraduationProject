using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsMenuUI : MonoBehaviour
{
    [SerializeField] private List<SkillBaseSO> skillSOList;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform skillCardTemplate;

    private void Awake()
    {
        //gameObject.SetActive(false);
    }

    private void Start()
    {
        skillCardTemplate.gameObject.SetActive(false);
        UpdateItemsMenu();
    }

    private void UpdateItemsMenu()
    {
        for (int i = 0; i < spawnPoint.childCount; i++)
        {
            if (spawnPoint.GetChild(i) == skillCardTemplate) continue;
            Destroy(spawnPoint.GetChild(i).gameObject);
        }

        foreach (var skillSO in skillSOList)
        {
            Transform skillCard = Instantiate(skillCardTemplate, spawnPoint).transform;
            skillCard.gameObject.SetActive(true);
            skillCard.GetComponent<SkillCardSingleUI>().SetItem(skillSO);
        }
       
    }

    public void CloseMenu(ShopMainMenuUI shopMainMenuUI)
    {
        shopMainMenuUI.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
