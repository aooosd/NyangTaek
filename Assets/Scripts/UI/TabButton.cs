using UnityEngine;
using UnityEngine.UI;

/// <summary>특정 패널과 연결되어 TabController에 탭 전환을 요청하는 버튼입니다.</summary>
public class TabButton : MonoBehaviour
{
    /// <summary>탭이 나타내는 화면 종류를 정의합니다.</summary>
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


    public GameObject panel; // 이 탭을 선택했을 때 표시할 패널입니다.

    TabController tabController; // 실제 패널 전환을 수행하는 컨트롤러입니다.
    public TabType tabType;      // 이 버튼이 나타내는 탭 종류입니다.
    
    /// <summary>탭 컨트롤러를 찾고 버튼 클릭 이벤트를 연결합니다.</summary>
    void Awake()
    {
        tabController = FindAnyObjectByType<TabController>();
        gameObject.GetComponent<Button>().onClick.AddListener(SwitchTab);
    }

    /// <summary>현재 탭을 활성화하도록 컨트롤러에 요청합니다.</summary>
    void SwitchTab()
    {
        tabController.SwitchTab(this);
    }
<<<<<<< Updated upstream
}
=======
}

>>>>>>> Stashed changes
