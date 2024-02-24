using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelMainMenuUI : MonoBehaviour
{
    [SerializeField] private List<MapSO> mapSOList;

    [SerializeField] private TravelSingleUI mapUITemplate;
    [SerializeField] private Transform mapUIParent;

    private void Start()
    {
        mapUITemplate.gameObject.SetActive(false);
        CreateMapUI();
    }

    private void CreateMapUI()
    {
        for (int i = 0; i < mapUIParent.childCount; i++)
        {
            if (mapUIParent.GetChild(i) == mapUITemplate.transform)
            {
                Debug.Log("a");
                continue;
            }

            Destroy(mapUIParent.GetChild(i).gameObject);
        }

        foreach (MapSO mapSO in mapSOList)
        {
            Transform mapUI = Instantiate(mapUITemplate.gameObject.transform, mapUIParent);
            mapUI.gameObject.SetActive(true);
            mapUI.GetComponent<TravelSingleUI>().SetMapSO(mapSO);
        }
    }
}
