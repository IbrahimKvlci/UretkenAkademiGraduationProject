using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject.Asteroids;

public class TravelSingleUI : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI textPrice;

    [SerializeField] private TravelUI travelUI;


    [field:SerializeField] public MapSO MapSO { get; set; }

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            travelUI.BuyButton(MapSO);
        });
    }

    public void SetMapSO(MapSO mapSO)
    {
        MapSO = mapSO;
        icon.sprite = mapSO.icon;
        text.text= mapSO.text;
        textPrice.text = mapSO.price.ToString();
    }
}
