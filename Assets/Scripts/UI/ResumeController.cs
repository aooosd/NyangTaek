using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>이력서 화면의 면접 시작과 취소 버튼 입력을 처리합니다.</summary>
public class ResumeController : MonoBehaviour
{
    ResumeModel resumeModel; // 선택된 지원자 정보를 보관하는 모델입니다.
    ResumeView resumeView;   // 지원자 정보를 표시하고 버튼을 제공하는 뷰입니다.


    /// <summary>모델과 뷰를 찾고 이력서 버튼 이벤트를 연결합니다.</summary>
    private void Awake()
    {
        resumeModel = GetComponent<ResumeModel>();
        resumeView = GetComponent<ResumeView>();

        resumeView.interviewButton.onClick.AddListener(OnInterviewButtonClicked);
        resumeView.cancelButton.onClick.AddListener(OnCancelButtonClicked);

        if (gameObject.name.Contains("ResumePanel_OnInterview"))
        {
            resumeView.cancelButton.GetComponentInChildren<TextMeshProUGUI>().text = "면접으로";
            resumeView.interviewButton.gameObject.SetActive(false);
        }
    }

    /// <summary>선택한 지원자 인덱스를 저장하고 면접 씬으로 이동합니다.</summary>
    void OnInterviewButtonClicked()
    {
        GameState.Instance.interviewIndex = resumeModel.index;
        SceneManager.LoadScene("InterviewScene");
    }

    /// <summary>현재 이력서 패널을 닫습니다.</summary>
    void OnCancelButtonClicked()
    {
        gameObject.SetActive(false);
    }
<<<<<<< Updated upstream
}
=======
}

>>>>>>> Stashed changes
