using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageBoxUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _message;

    private void Start()
    {
        Player.Instance.PlayerTriggerCheck.OnInteractableObjectTriggered += PlayerTriggerCheck_OnInteractableObjectTriggered;
        Player.Instance.PlayerTriggerCheck.OnInteractableObjectNotTriggered += PlayerTriggerCheck_OnInteractableObjectNotTriggered;
    }

    private void PlayerTriggerCheck_OnInteractableObjectNotTriggered(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void PlayerTriggerCheck_OnInteractableObjectTriggered(object sender, PlayerTriggerCheck.OnInteractableObjectTriggeredEventArgs e)
    {
        Show();
        UpdateMessage(e.interactable.Message);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void UpdateMessage(string message)
    {
        _message.text = message;
    }
}
