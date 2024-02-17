using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class WeaponController : MonoBehaviour
{
    [field: SerializeField] public List<WeaponSO> WeaponSOList { get; set; }

    [SerializeField] private Transform weaponPoint;

    private WeaponSO currentWeapon;


    private IWeaponService weaponService;
    private IGameInputSystem _gameInputSystem;

    [Inject]
    public void Construct(IGameInputSystem gameInputSystem)
    {
        _gameInputSystem = gameInputSystem;
    }

    private void Awake()
    {
        weaponService=new WeaponManager();
    }

    private void Start()
    {
        _gameInputSystem.OnMouseWheelScrolled += GameInputSystem_OnMouseWheelScrolled;

        if (WeaponSOList.Count > 0)
        {
            weaponService.CreateWeapon(WeaponSOList[0], weaponPoint,out currentWeapon);
        }
    }

    private void GameInputSystem_OnMouseWheelScrolled(object sender, System.EventArgs e)
    {
        Debug.Log(_gameInputSystem.GetMouseWheelValueNormalized());

        currentWeapon=weaponService.GetNewWeapon(currentWeapon,WeaponSOList, _gameInputSystem.GetMouseWheelValueNormalized());
        weaponService.CreateWeapon(currentWeapon,weaponPoint,out currentWeapon);
    }

    
}
