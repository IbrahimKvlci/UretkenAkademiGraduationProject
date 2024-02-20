using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private Dealer dealer;

    private IShopService shopService;

    private void Awake()
    {
        shopService = new ShopManager();
    }

    private void Start()
    {
        dealer.DealerService.OnInteract += DealerService_OnInteract;
        Hide();
    }

    private void DealerService_OnInteract(object sender, System.EventArgs e)
    {
        if (gameObject.active)
        {
            Hide();
        }
        else
        {
            Show();
        }
        Debug.Log("yes");

    }

    public void BuyButton(ProductSO productSO)
    {
        shopService.BuyProduct(productSO, Player.Instance);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        Player.Instance.IsPlayerPaused = true;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        Player.Instance.IsPlayerPaused = false;

    }
}
