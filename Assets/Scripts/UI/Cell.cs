using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    Button button;
    Image cellImage;
    Text nameText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
