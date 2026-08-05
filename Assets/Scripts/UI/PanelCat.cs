using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 스크롤뷰에 고양이 업데이트(갱신)
/// </summary>
public class PanelCat : MonoBehaviour
{
    Text titleText;
    Transform content;
    public GameObject cellPrefab;

    private void Awake()
    {
        titleText = transform.Find("TitleText").GetComponent<Text>();
        content = transform.Find("Scroll View/Viewport/Content");
        Debug.Log("FOUND:" + content.name);
    }

    private void OnEnable()
    {
        UIMgr.Instance.RefreshList(GameState.Instance.ownedCats, content, cellPrefab);
    }
}
