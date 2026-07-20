using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResumeView : MonoBehaviour
{
    private ResumeModel resumeModel;
    
    //
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI jobText;
    public TextMeshProUGUI ageText;

    public TextMeshProUGUI hashtagText_0;
    public TextMeshProUGUI hashtagText_1;
    public TextMeshProUGUI hashtagText_2;
    
    public TextMeshProUGUI prosText;
    public TextMeshProUGUI consText;
    public TextMeshProUGUI featuresText_0;
    public TextMeshProUGUI featuresText_1;
    public TextMeshProUGUI featuresText_2;
    
    private void Awake()
    {
        resumeModel = GetComponent<ResumeModel>();
        
    }

    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        nameText.text = resumeModel.applicantData.name;
        
    }
}
