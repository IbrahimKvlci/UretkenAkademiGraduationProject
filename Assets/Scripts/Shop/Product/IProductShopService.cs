using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProductShopService
{
    void Buy(ProductSO productSO,Player player);
}
