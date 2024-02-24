using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShopManager : IProductShopService
{
    public void Buy(ProductSO productSO, Player player)
    {
        player.WeaponController.WeaponSOList.Add((WeaponSO)productSO);

        PlayerPrefsSavingSystem.SetList<WeaponSO>(PlayerPrefsSavingSystem.PlayerPrefsNameEnum.Weapons, player.WeaponController.WeaponSOList);
    }
}
