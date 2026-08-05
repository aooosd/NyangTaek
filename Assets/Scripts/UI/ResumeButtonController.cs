using UnityEngine;
using UnityEngine.UI;

/// <summary>지원자 선택 버튼과 이력서 패널을 연결합니다.</summary>
public class ResumeButtonController : MonoBehaviour
{
    Button button;                 // 이 컴포넌트가 연결된 지원자 선택 버튼입니다.
    public int Index;              // 버튼이 가리키는 지원자의 배열 인덱스입니다.
    public GameObject resumePanel; // 선택한 지원자의 이력서를 표시할 패널입니다.

    /// <summary>Button 컴포넌트를 찾고 클릭 이벤트를 연결합니다.</summary>
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClicked);
    }

    /// <summary>선택 인덱스를 모델에 전달하고 이력서 패널을 초기화해 표시합니다.</summary>
    void OnButtonClicked()
    {
        resumePanel.GetComponent<ResumeModel>().index = this.Index;
        resumePanel.SetActive(true);
        
        resumePanel.GetComponent<ResumeView>().Initialize();
    }
<<<<<<< Updated upstream
}
=======
}

>>>>>>> Stashed changes
