using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyGoldUI : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private TextMeshProUGUI goldText;

    private void Start()
    {
        enemy.EnemyHealthService.OnEnemyDeath += EnemyHealthService_OnEnemyDeath;

        gameObject.SetActive(false);
        UpdateGoldText();
    }

    private void EnemyHealthService_OnEnemyDeath(object sender, System.EventArgs e)
    {
        gameObject.SetActive(true);
    }

    private void UpdateGoldText()
    {
        goldText.text = $"+{enemy.EnemySO.gold}";
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
