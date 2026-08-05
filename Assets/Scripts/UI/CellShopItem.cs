using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 상점에서 쓸 Cell 아이템을 의미한다.
/// </summary>
public class CellShopItem : Cell
{
    int price;
    Text priceText;
    
    public void SetPrice(int price)
    {
        this.price = price;
    }
}
