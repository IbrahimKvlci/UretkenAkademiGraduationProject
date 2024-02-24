using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelUI : MonoBehaviour
{
    [SerializeField] private Travel travel;

    private IShopService shopService;

    private void Awake()
    {
        shopService = new ShopManager();
    }

    private void Start()
    {
        travel.TravelService.OnTravelInteract += TravelService_OnTravelInteract;
        Hide();
    }

    private void TravelService_OnTravelInteract(object sender, System.EventArgs e)
    {
        if (gameObject.active)
        {
            Hide();
        }
        else
        {
            Show();
        }
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
