using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldText;

    private void Start()
    {
        Player.Instance.PlayerGoldService.OnPlayerGoldChanged += PlayerGoldService_OnPlayerGoldChanged;

        UpdateGoldText();
    }

    private void PlayerGoldService_OnPlayerGoldChanged(object sender, System.EventArgs e)
    {
        UpdateGoldText();
    }

    private void UpdateGoldText()
    {
        goldText.text = Player.Instance.PlayerGoldService.Gold.ToString();
    }
}
