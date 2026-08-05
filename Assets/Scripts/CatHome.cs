using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>선택한 고양이와 집사의 정보를 표시하고 성향 차이로 만족도를 계산합니다.</summary>
public class CatHome : MonoBehaviour
{
    CatData currentCat;             // 현재 선택된 고양이 데이터입니다.
    ApplicantData currentServant;  // 현재 배정된 집사 데이터입니다.
    public int catId;               // 현재 선택된 고양이의 데이터 ID입니다.
    public int servantId;           // 현재 선택된 집사의 데이터 ID입니다.

    public Text catNameText;                 // 선택한 고양이의 이름을 표시합니다.
    public Button servantButton;             // 집사 선택 UI를 여는 버튼입니다.
    public GameObject servantSelectPanel;    // 집사 선택 목록 패널입니다.

    public TextMeshProUGUI servantNameText;  // 현재 집사의 이름을 표시합니다.
    public TextMeshProUGUI satisfactionText; // 고양이와 집사의 만족도를 표시합니다.
    public Image imageCat;                   // 선택한 고양이 이미지를 표시합니다.

    /// <summary>기본 집사 ID를 지정합니다.</summary>
    private void Awake()
    {
        servantId = 1; //
    }

    /// <summary>화면이 열릴 때 현재 집사 데이터를 데이터베이스에서 가져옵니다.</summary>
    private void OnEnable()
    {
        currentServant = GameDatabase.Instance.Applicants.applicants[servantId - 1];
    }

    /// <summary>현재 집사의 이름을 화면에 갱신합니다.</summary>
    void Update()
    {
        if (servantId >= 0 && servantId <= GameState.Instance.ownedApplicants.Count)
        {
            servantNameText.text = "현재 집사\n" + currentServant.GetName();
        }

        
    }

    /// <summary>표시할 고양이 ID를 설정하고 화면을 초기화합니다.</summary>
    public void SetId(int _value)
    {
        catId = _value;
        Initialize();
    }

    /// <summary>고양이 데이터, 이미지, 이름과 만족도를 갱신합니다.</summary>
    void Initialize()
    {
        currentCat = GameDatabase.Instance.Cats.cats[catId - 1];
        imageCat.sprite = GameDatabase.Instance.spritesCats[catId - 1];
        catNameText.text = GameDatabase.Instance.Cats.cats[catId - 1].GetName();

        SatisfactionCalculate();
    }

    /// <summary>고양이와 집사의 세 가지 성향 차이를 합산해 만족도를 표시합니다.</summary>
    void SatisfactionCalculate()
    {
        int difCloseness = Mathf.Abs(currentCat.closeness - currentServant.closeness);          // 밀착도 차이입니다.
        int difActivity = Mathf.Abs(currentCat.activity - currentServant.activity);             // 활동성 차이입니다.
        int difIndependence = Mathf.Abs(currentCat.independence - currentServant.independence); // 독립성 차이입니다.

        int difTotal = difActivity + difCloseness + difIndependence; // 세 성향의 전체 차이입니다.
        Debug.Log(difTotal);
        if (difTotal >= 0 && difTotal < 3)
        {
            satisfactionText.text = "만족도 : 좋음";
        }
        else if (difTotal >= 3 && difTotal < 6)
        {
            satisfactionText.text = "만족도 : 보통";
        }
        else if (difTotal >= 6)
        {
            satisfactionText.text = "만족도 : 나쁨";
        }
    }
}

