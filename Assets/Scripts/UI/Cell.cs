using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 스크롤 되는 아이템 하나를 의미한다.
/// </summary>
public class Cell : MonoBehaviour
{
    Button button;      // 셀 클릭 입력을 받는 버튼입니다.
    Image cellImage;    // 셀의 대표 이미지를 표시합니다.
    Text nameText;      // 셀의 데이터 이름을 표시합니다.
    
    /// <summary>셀 내부 UI 참조를 찾고 클릭 이벤트를 연결합니다.</summary>
    protected virtual void Awake()
    {
        button = GetComponentInChildren<Button>();
        cellImage = transform.Find("Image").GetComponent<Image>();
        nameText = GetComponentInChildren<Text>();
        button.onClick.AddListener(OnCellClicked);
    }

    /// <summary>셀 클릭 시 파생 클래스가 동작을 구현할 수 있는 확장 지점입니다.</summary>
    protected virtual void OnCellClicked()
    {

    }

    /// <summary>셀의 대표 이미지와 이름 텍스트를 갱신합니다.</summary>
    /// <param name="sp">셀에 표시할 스프라이트입니다.</param>
    /// <param name="txt">셀에 표시할 이름입니다.</param>
    public virtual void Initialize(Sprite sp, string txt)
    {
        cellImage.sprite = sp;
        nameText.text = txt;
    }
<<<<<<< Updated upstream
}
=======
}

>>>>>>> Stashed changes
