using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerPrefsSavingSystem : MonoBehaviour
{

    public enum PlayerPrefsNameEnum
    {
        Gold,
        Weapons,
        Skills
    }

    private void Start()
    {
        Player.Instance.PlayerGoldService.OnPlayerGoldChanged += PlayerGoldService_OnPlayerGoldChanged;

        Player.Instance.PlayerGoldService.Gold=GetInt(PlayerPrefsNameEnum.Gold);
    }

    private void PlayerGoldService_OnPlayerGoldChanged(object sender, System.EventArgs e)
    {
        SetInt(PlayerPrefsNameEnum.Gold,Player.Instance.PlayerGoldService.Gold);
    }

    public void SetInt(PlayerPrefsNameEnum playerPrefsNameEnum,int value)
    {
        PlayerPrefs.SetInt(playerPrefsNameEnum.ToString(),value);
    }

    public int GetInt(PlayerPrefsNameEnum playerPrefsNameEnum)
    {
        return PlayerPrefs.GetInt(playerPrefsNameEnum.ToString(),0);
    }

    public void SetFloat(PlayerPrefsNameEnum playerPrefsNameEnum,float value)
    {
        PlayerPrefs.SetFloat(playerPrefsNameEnum.ToString(),value);
    }

    public static void SetBool(PlayerPrefsNameEnum playerPrefsNameEnum, bool value)
    {
        PlayerPrefs.SetInt(playerPrefsNameEnum.ToString(), Convert.ToInt32(value));
    }

    public static bool GetBool(PlayerPrefsNameEnum playerPrefsNameEnum)
    {
        return Convert.ToBoolean(PlayerPrefs.GetInt(playerPrefsNameEnum.ToString()));
    }

    public static void SetObject<T>(PlayerPrefsNameEnum playerPrefsNameEnum,T value)
    {
        PlayerPrefsExtra.SetObject<T>(playerPrefsNameEnum.ToString(), value);
    }

    public static void SetList<T>(PlayerPrefsNameEnum playerPrefsNameEnum,List<T> list)
    {
        PlayerPrefsExtra.SetList<T>(playerPrefsNameEnum.ToString(),list);
    }

    public static List<T> GetList<T>(PlayerPrefsNameEnum playerPrefsNameEnum)
    {
        return PlayerPrefsExtra.GetList<T>(playerPrefsNameEnum.ToString());
    }

    public static List<T> GetList<T>(PlayerPrefsNameEnum playerPrefsNameEnum,List<T> defaultValue)
    {
        return PlayerPrefsExtra.GetList<T>(playerPrefsNameEnum.ToString(),defaultValue);
    }


}
