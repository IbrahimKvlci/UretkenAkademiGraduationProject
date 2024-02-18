using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsMenuUI : MonoBehaviour
{
    [SerializeField] private List<WeaponSO> weaponSOList;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform itemCardTemplate;

    private void Awake()
    {
        //gameObject.SetActive(false);
    }

    private void Start()
    {
        itemCardTemplate.gameObject.SetActive(false);
        UpdateItemsMenu();
    }

    private void UpdateItemsMenu()
    {
        for (int i = 0; i < spawnPoint.childCount; i++)
        {
            if (spawnPoint.GetChild(i) == itemCardTemplate) continue;
            Destroy(spawnPoint.GetChild(i).gameObject);
        }

        foreach (var weaponSO in weaponSOList)
        {
            Transform itemCard = Instantiate(itemCardTemplate, spawnPoint).transform;
            itemCard.gameObject.SetActive(true);
            itemCard.GetComponent<ItemCardSingleUI>().SetItem(weaponSO);
        }
       
    }

    public void CloseMenu(ShopMainMenuUI shopMainMenuUI)
    {
        shopMainMenuUI.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
