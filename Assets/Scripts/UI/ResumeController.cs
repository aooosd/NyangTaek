using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResumeController : MonoBehaviour
{
    ResumeModel resumeModel;
    ResumeView resumeView;


    private void Awake()
    {
        resumeModel = GetComponent<ResumeModel>();
        resumeView = GetComponent<ResumeView>();

        resumeView.interviewButton.onClick.AddListener(OnInterviewButtonClicked);
        resumeView.cancelButton.onClick.AddListener(OnCancelButtonClicked);
    }

    void OnInterviewButtonClicked()
    {
        GameState.Instance.interviewIndex = resumeModel.index;
        SceneManager.LoadScene("InterviewScene");
    }

    void OnCancelButtonClicked()
    {
        gameObject.SetActive(false);
    }
}
