using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMainMenuUI : MonoBehaviour
{
    private void Awake()
    {
        //gameObject.SetActive(false);
    }

    public void OpenMenu(GameObject menu)
    {
        menu.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void Close(GameObject shop)
    {
        shop.gameObject.SetActive(false);
    }
}
