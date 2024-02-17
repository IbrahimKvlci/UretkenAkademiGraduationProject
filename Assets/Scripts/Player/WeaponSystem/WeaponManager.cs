using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : IWeaponService
{
    public WeaponSO GetNewWeapon(WeaponSO currentWeapon, List<WeaponSO> weaponSOList, int value)
    {
        int indexCurrentWeapon=weaponSOList.IndexOf(currentWeapon);
        int newIndex=indexCurrentWeapon+value;

        if ((newIndex > weaponSOList.Count - 1)|| (newIndex<0))
        {
            newIndex = (weaponSOList.Count - 1) / Mathf.Abs(newIndex);
        }

        return weaponSOList[newIndex];
    }

    public void CreateWeapon(WeaponSO weaponSO, Transform point,out WeaponSO currentWeapon)
    {
        for (int i = 0; i < point.childCount; i++)
        {
            GameObject.Destroy(point.GetChild(i).gameObject);
        }

        Transform weapon = GameObject.Instantiate(weaponSO.prefab.transform);
        weapon.SetParent(point);
        weapon.transform.localPosition = Vector3.zero;
        weapon.transform.localRotation = Quaternion.identity;

        currentWeapon=weaponSO;
    }
}
