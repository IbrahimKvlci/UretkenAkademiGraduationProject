using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private List<MapSO> mapSOList;

    private void Awake()
    {
        foreach (MapSO item in mapSOList)
        {
            item.ProductShopService = new MapShopManager();
        }
    }
}
