using UnityEngine;
using UnityEngine.UI;
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
