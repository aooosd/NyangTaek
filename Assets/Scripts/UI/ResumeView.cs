using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>ResumeModel의 지원자 정보를 이력서 UI 요소에 표시합니다.</summary>
public class ResumeView : MonoBehaviour
{
    private ResumeModel resumeModel; // 현재 이력서 화면이 참조하는 데이터 모델입니다.

    //
    [SerializeField] Image applicantImage;      // 지원자 얼굴 이미지를 표시합니다.
    [SerializeField] TextMeshProUGUI nameText;  // 지원자 이름을 표시합니다.
    [SerializeField] TextMeshProUGUI jobText;   // 지원자 직업을 표시합니다.
    [SerializeField] TextMeshProUGUI ageText;   // 지원자 나이를 표시합니다.

    [SerializeField] TextMeshProUGUI hashtagText_0; // 활동성 해시태그를 표시합니다.
    [SerializeField] TextMeshProUGUI hashtagText_1; // 독립성 해시태그를 표시합니다.
    [SerializeField] TextMeshProUGUI hashtagText_2; // 밀착도 해시태그를 표시합니다.

    [SerializeField] TextMeshProUGUI prosText;       // 지원자의 장점을 표시합니다.
    [SerializeField] TextMeshProUGUI consText;       // 지원자의 단점을 표시합니다.
    [SerializeField] TextMeshProUGUI featuresText_0; // 첫 번째 특징을 표시합니다.
    [SerializeField] TextMeshProUGUI featuresText_1; // 두 번째 특징을 표시합니다.
    [SerializeField] TextMeshProUGUI featuresText_2; // 세 번째 특징을 표시합니다.

    public Button interviewButton; // 해당 지원자의 면접을 시작하는 버튼입니다.
    public Button cancelButton;    // 이력서 패널을 닫는 버튼입니다.

    /// <summary>같은 게임 오브젝트의 ResumeModel을 가져옵니다.</summary>
    private void Awake()
    {
        resumeModel = GetComponent<ResumeModel>();
    }

    /// <summary>화면이 처음 시작될 때 이력서 내용을 표시합니다.</summary>
    void Start()
    {
        Initialize();
    }

    /// <summary>모델의 지원자 정보를 이미지와 각 텍스트 UI에 반영합니다.</summary>
    public void Initialize()
    {
        ApplicantData data = resumeModel.applicantData; // UI에 표시할 현재 지원자 데이터입니다.

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
