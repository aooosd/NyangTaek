using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 상점에서 쓸 Cell 아이템을 의미한다.
/// </summary>
public class CellShopItem : Cell
{
    int price;          // 상점에서 판매하는 아이템 가격입니다.
    Text priceText;     // 가격을 화면에 표시할 텍스트입니다.
    
    /// <summary>상점 셀에 사용할 판매 가격을 저장합니다.</summary>
    public void SetPrice(int price)
    {
        this.price = price;
    }
}
