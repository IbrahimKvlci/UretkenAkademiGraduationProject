using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject.Asteroids;

public class SkillCardSingleUI : MonoBehaviour
{
    public SkillBaseSO SkillBaseSO { get; set; }

    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private Shop shop;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            shop.BuyButton(SkillBaseSO);
        });
    }

    public void SetItem(SkillBaseSO skillSO)
    {
        SkillBaseSO=skillSO;
        icon.sprite = skillSO.icon;
        text.text = skillSO.text;
        priceText.text=skillSO.price.ToString();
    }
}
