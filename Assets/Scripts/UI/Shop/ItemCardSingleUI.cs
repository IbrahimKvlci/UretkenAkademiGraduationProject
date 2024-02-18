using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCardSingleUI : MonoBehaviour
{
    [SerializeField] public WeaponSO WeaponSO { get; set; }
    [SerializeField] private Shop shop;

    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI priceText;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            shop.BuyButton(WeaponSO);
        });
    }

    public void SetItem(WeaponSO weaponSO)
    {
        WeaponSO = weaponSO;
        icon.sprite = weaponSO.icon;
        text.text = weaponSO.name;
        priceText.text = weaponSO.price.ToString();
    }
}
