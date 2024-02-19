using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBarUI : MonoBehaviour
{
    [SerializeField] private Image HealthBar;

    private void Start()
    {
        Player.Instance.PlayerHealthService.OnHealthChanged += PlayerHealthService_OnHealthChanged;
    }

    private void PlayerHealthService_OnHealthChanged(object sender, System.EventArgs e)
    {
        HealthBar.fillAmount = Player.Instance.PlayerHealthService.Health / Player.Instance.PlayerSO.maxHealth;
    }
}
