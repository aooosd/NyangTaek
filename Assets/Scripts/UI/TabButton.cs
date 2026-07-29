using UnityEngine;
using UnityEngine.UI;

public class TabButton : MonoBehaviour
{
    public GameObject panel;

    TabController parent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        parent = GetComponentInParent<TabController>();
        gameObject.GetComponent<Button>().onClick.AddListener(SwitchTab);
    }

    void SwitchTab()
    {
        parent.SwitchTab(this);
    }
}
