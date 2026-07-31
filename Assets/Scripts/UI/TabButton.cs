using UnityEngine;
using UnityEngine.UI;

public class TabButton : MonoBehaviour
{
    public enum TabType
    {
        Cat,
        Servant,
        Item,
        Interview,
        CatHome,
        ServantSelect,
        Shop,
        CatDetailed,
        ServantDetailed
    }


    public GameObject panel;

    TabController tabController;
    public TabType tabType;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        tabController = FindAnyObjectByType<TabController>();
        gameObject.GetComponent<Button>().onClick.AddListener(SwitchTab);
    }

    void SwitchTab()
    {
        tabController.SwitchTab(this);
    }
}
