using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 스크롤 되는 아이템 하나를 의미한다.
/// </summary>
public class Cell : MonoBehaviour
{
    Button button;
    Image cellImage;
    Text nameText;
    
    protected virtual void Awake()
    {
        button = GetComponentInChildren<Button>();
        cellImage = transform.Find("Image").GetComponent<Image>();
        nameText = GetComponentInChildren<Text>();
        button.onClick.AddListener(OnCellClicked);
    }

    protected virtual void OnCellClicked()
    {

    }

    public virtual void Initialize(Sprite sp, string txt)
    {
        cellImage.sprite = sp;
        nameText.text = txt;
    }
}
