using UnityEngine;
using UnityEngine.UI;

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
