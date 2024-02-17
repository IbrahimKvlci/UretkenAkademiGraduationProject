using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeaponService
{
    void CreateWeapon(WeaponSO weaponSO, Transform point,out WeaponSO currentWeapon);
    WeaponSO GetNewWeapon(WeaponSO currentWeapon,List<WeaponSO> weaponSOList, int value);
}
