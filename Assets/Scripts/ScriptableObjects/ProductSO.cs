using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductSO : ScriptableObject
{
    public int price;
    public string text;
    public Sprite icon;

    public IProductShopService ProductShopService { get; set; }

    protected virtual void Buy()
    {

    }
}
