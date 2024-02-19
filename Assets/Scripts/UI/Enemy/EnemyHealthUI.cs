using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private Image healthBarImage;

    private void Start()
    {
        enemy.EnemyHealthService.OnEnemyHealthChanged += EnemyHealthService_OnEnemyHealthChanged;

        UpdateHealthBar();
    }

    private void EnemyHealthService_OnEnemyHealthChanged(object sender, System.EventArgs e)
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        healthBarImage.fillAmount = (float)enemy.EnemyHealthService.Health / enemy.EnemySO.maxHealth;
        Debug.Log(enemy.EnemyHealthService.Health);
    }
}
