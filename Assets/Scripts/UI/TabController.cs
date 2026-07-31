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
        for (int i = 0; i < tabs.Length; i++) // ¸ðµç ÅÇÀ» Å½»ö
        {
            tabs[i].panel.SetActive(false);    // ÅÇÀÇ ÆÐ³ÎÀ» ÇÏ³ªÇÏ³ª¾¿ ²ö´Ù.
        }

        for (int i = 0; i < tabs.Length; i++) // ¸ðµç ÅÇÀ» Å½»ö
        {
            if (btn == tabs[i])
            {
                tabs[i].panel.SetActive(true);  // ¹öÆ°¿¡ ÇØ´çÇÏ´Â ÅÇ¸¸ ÄÒ´Ù.
                break;                          // ¿øÇÏ´Â ÅÇÀ» Ã£¾ÒÀ¸´Ï Å»Ãâ
            }
                
        }
    }
}
