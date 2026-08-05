using UnityEngine;

/// <summary>등록된 탭 패널 가운데 선택된 패널 하나만 표시합니다.</summary>
public class TabController : MonoBehaviour
{
    public TabButton[] tabs; // 전환 대상으로 등록된 모든 탭 버튼입니다.

    /// <summary>탭 자동 검색 등이 필요할 때 사용할 초기화 지점입니다.</summary>
    void Start()
    {
        //tabs = FindObjectsByType<TabButton>();
    }

    /// <summary>모든 패널을 숨긴 뒤 전달받은 탭의 패널만 표시합니다.</summary>
    /// <param name="btn">사용자가 선택한 탭 버튼입니다.</param>
    public void SwitchTab(TabButton btn)
    {
        for (int i = 0; i < tabs.Length; i++) // 모든 탭을 탐색
        {
            tabs[i].panel.SetActive(false);    // 탭의 패널을 하나하나씩 끈다.
        }

        for (int i = 0; i < tabs.Length; i++) // 모든 탭을 탐색
        {
            if (btn == tabs[i])
            {
                tabs[i].panel.SetActive(true);  // 버튼에 해당하는 탭만 켠다.
                break;                          // 원하는 탭을 찾았으니 탈출
            }
                
        }
    }
}