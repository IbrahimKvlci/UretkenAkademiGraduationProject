using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShopManager : IProductShopService
{
    public void Buy(ProductSO productSO, Player player)
    {
        if (player.PlayerGoldService.Gold >= productSO.price)
        {
            player.PlayerGoldService.Gold -= productSO.price;
            player.WeaponController.WeaponSOList.Add((WeaponSO)productSO);

            PlayerPrefsSavingSystem.SetList<WeaponSO>(PlayerPrefsSavingSystem.PlayerPrefsNameEnum.Weapons, player.WeaponController.WeaponSOList);
        }
        else
        {
            //Player's gold is not enough
            Debug.Log("Your gold is not enough");
        }
    }
}
