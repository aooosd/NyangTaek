using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResumeView : MonoBehaviour
{
    private ResumeModel resumeModel;

    //
    [SerializeField] Image applicantImage;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI jobText;
    [SerializeField] TextMeshProUGUI ageText;

    [SerializeField] TextMeshProUGUI hashtagText_0;
    [SerializeField] TextMeshProUGUI hashtagText_1;
    [SerializeField] TextMeshProUGUI hashtagText_2;

    [SerializeField] TextMeshProUGUI prosText;
    [SerializeField] TextMeshProUGUI consText;
    [SerializeField] TextMeshProUGUI featuresText_0;
    [SerializeField] TextMeshProUGUI featuresText_1;
    [SerializeField] TextMeshProUGUI featuresText_2;

    public Button interviewButton;
    public Button cancelButton;

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

        applicantImage.sprite = GameDatabase.Instance.spritesApplicants[resumeModel.index];

        nameText.text = "이름 : " + data.name;
        jobText.text = "직업 : " + data.job;
        ageText.text = "나이 : " + data.age.ToString();

        //hashtagText_0.text = "#" + data.ConvertToHashTag(StatType.activity);
        //hashtagText_1.text = "#" + data.ConvertToHashTag(StatType.independence);
        //hashtagText_2.text = "#" + data.ConvertToHashTag(StatType.closeness);

        prosText.text = data.pros;
        consText.text = data.cons;
        featuresText_0.text = data.feature1;
        featuresText_1.text = data.feature2;
        featuresText_2.text = data.feature3;
    }
}
