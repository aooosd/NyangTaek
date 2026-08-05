using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 고용한 집사 지원자를 스크롤 목록으로 표시하고 활성화될 때 갱신합니다.
/// </summary>
public class PanelServant : MonoBehaviour
{
    Text titleText;               // 패널 제목을 표시하는 텍스트입니다.
    Transform content;            // 생성된 집사 셀이 배치될 부모 Transform입니다.
    public GameObject cellPrefab; // 집사 셀 생성에 사용할 프리팹입니다.

    /// <summary>계층 구조에서 제목과 Scroll View의 Content를 찾습니다.</summary>
    private void Awake()
    {
        titleText = transform.Find("TitleText").GetComponent<Text>();
        content = transform.Find("Scroll View/Viewport/Content");
        Debug.Log("FOUND:" + content.name);
    }

    /// <summary>패널이 열릴 때 고용한 집사 목록을 다시 생성합니다.</summary>
    private void OnEnable()
    {
        UIMgr.Instance.RefreshList(GameState.Instance.ownedApplicants, content, cellPrefab);
    }
}

