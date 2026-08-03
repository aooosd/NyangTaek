using UnityEngine;
using UnityEngine.UI;

public class ResumeButtonController : MonoBehaviour
{
    Button button;
    public int Index;
    public GameObject resumePanel;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClicked);
    }

    void OnButtonClicked()
    {
        resumePanel.GetComponent<ResumeModel>().index = this.Index;
        resumePanel.SetActive(true);
        
        resumePanel.GetComponent<ResumeView>().Initialize();
    }
}
