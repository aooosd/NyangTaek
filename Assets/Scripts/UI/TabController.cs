using UnityEngine;

public class TabController : MonoBehaviour
{
    TabButton[] tabs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tabs = FindObjectsByType<TabButton>();
    }

    public void SwitchTab(TabButton btn)
    {
        for (int i = 0; i < tabs.Length; i++)
        {
            tabs[i].panel.SetActive(btn == tabs[i]);

            /*if (btn == tabs[i])
            {
                btn.panel.SetActive(true);
            }
            else
            {
                tabs[i].panel.SetActive(false);
            }*/
        }
    }
}
