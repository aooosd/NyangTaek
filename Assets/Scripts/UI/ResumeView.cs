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
        ApplicantData data = resumeModel.applicantData;

        // TODO: 기획팀에게 초기화할 stat 알려달라고 해주세요.
        //data.Initialize(3, 5, 4);

        nameText.text = data.name;
        jobText.text = data.job;
        ageText.text = data.age.ToString();

        hashtagText_0.text = "#" + data.ConvertToHashTag(StatType.activity);
        hashtagText_1.text = "#" + data.ConvertToHashTag(StatType.independence);
        hashtagText_2.text = "#" + data.ConvertToHashTag(StatType.closeness);

        prosText.text = data.pros;
        consText.text = data.cons;
        featuresText_0.text = data.feature1;
        featuresText_1.text = data.feature2;
        featuresText_2.text = data.feature3;
    }
}
