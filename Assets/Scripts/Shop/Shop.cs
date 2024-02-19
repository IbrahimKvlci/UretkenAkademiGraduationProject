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
        gameObject.SetActive(false);
    }

    private void DealerService_OnInteract(object sender, System.EventArgs e)
    {
        gameObject.SetActive(!gameObject.active);
        Debug.Log("yes");

    }

    public void BuyButton(ProductSO productSO)
    {
        shopService.BuyProduct(productSO, Player.Instance);
    }
}
