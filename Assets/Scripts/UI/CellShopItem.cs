using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 상점에서 쓸 Cell 아이템을 의미한다.
/// </summary>
public class CellShopItem : Cell
{
    int price;
    Text priceText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPrice(int price)
    {
        this.price = price;
    }
}
