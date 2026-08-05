using System.Linq;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>집사 지원자 면접의 행동 선택, 대화 기록, 채용 결과와 화면 전환을 관리합니다.</summary>
public class InterviewMgr : MonoBehaviour
{
    int Index = 0;              // 현재 면접 중인 지원자의 배열 인덱스입니다.
    int questionCount = 0;      // 이번 면접에서 실행한 행동 수입니다.
    int maxQuestionCount = 3;   // 한 번의 면접에서 실행할 수 있는 최대 행동 수입니다.

    [Header("Interview")]
<<<<<<< Updated upstream
    public Button ApproachBtn; // 다가가기 행동 버튼입니다.
    public Button StareBtn;    // 노려보기 행동 버튼입니다.
    public Button SmellBtn;    // 냄새 맡기 행동 버튼입니다.
    public Button IgnoreBtn;   // 위협하기 행동 버튼입니다.
    public Button DecideBtn;   // 채용 여부 결정 패널을 여는 버튼입니다.
    public Button AcceptBtn;   // 지원자를 채용하는 버튼입니다.
    public Button RejectBtn;   // 지원자를 거절하는 버튼입니다.

    public GameObject ExActPanel; // 추가 행동을 표시할 패널입니다.
=======
    // 占썩본 占썅동 占쏙옙튼占쏙옙
    public Button ApproachBtn;
    public Button StareBtn;
    public Button SmellBtn;
    public Button IgnoreBtn;
    public Button DecideBtn;
    public Button AcceptBtn;
    public Button RejectBtn;

    public GameObject ExActPanel; // 占쌩곤옙 占썅동 占싻놂옙
>>>>>>> Stashed changes

    public Text CountText; // 남은 행동 횟수를 표시합니다.

    [Header("Result")]
    public Text ResultText; // 채용 여부 결과 문구를 표시합니다.
    public Button NextBtn;  // 다음 지원자로 넘어가기 위한 버튼입니다.
    public Button TownBtn;  // 마을 화면으로 돌아가는 버튼입니다.

    public Image applicantImage; // 현재 지원자의 이미지를 표시합니다.

    public GameObject GanteakPanel; // 채용 또는 거절을 선택하는 간택 패널입니다.
    public GameObject ResultPanel;  // 면접 결과를 표시하는 패널입니다.
    public GameObject DialogBox;    // 생성된 대화 로그가 배치되는 부모 오브젝트입니다.

    public GameObject textPrefab; // 대화 한 줄을 생성할 Text 프리팹입니다.

    public GameObject memoPanel;   // 면접 메모를 표시하는 패널입니다.
    public GameObject resumePanel; // 지원자 이력서를 표시하는 패널입니다.

<<<<<<< Updated upstream
    string catName = "고양이"; // 대화 로그에 표시할 고양이 화자 이름입니다.
=======
    string catName = "怨좎뼇??;
>>>>>>> Stashed changes

    bool hasApproached = false; // 다가가기 행동을 이미 사용했는지 나타냅니다.
    bool hasStared = false;     // 노려보기 행동을 이미 사용했는지 나타냅니다.
    bool hasSmelled = false;    // 냄새 맡기 행동을 이미 사용했는지 나타냅니다.
    bool hasThreatened = false; // 위협하기 행동을 이미 사용했는지 나타냅니다.

    /// <summary>현재 면접 대상을 가져오고 버튼 이벤트를 연결한 뒤 면접을 시작합니다.</summary>
    void Start()
    {
        Index = GameState.Instance.interviewIndex; // 占쏙옙占쏙옙 占쏙옙占쏙옙 占쏙옙占쏙옙 占쌍댐옙 占쏙옙占쏙옙占쏙옙占쏙옙 占싸듸옙占쏙옙
        ApproachBtn.onClick.AddListener(Approach);
        StareBtn.onClick.AddListener(Stare);
        SmellBtn.onClick.AddListener(Smell);
        IgnoreBtn.onClick.AddListener(Threat);

        GanteakPanel.SetActive(false);
        DecideBtn.onClick.AddListener(Decide);
        AcceptBtn.onClick.AddListener(() => ShowResult(true));
        RejectBtn.onClick.AddListener(() => ShowResult(false));
        //NextBtn.onClick.AddListener(Next);
        TownBtn.onClick.AddListener(Town);

        StartInterview();
    }

    /// <summary>남은 행동 횟수 UI를 현재 상태에 맞게 갱신합니다.</summary>
    void Update()
    {
        ShowCount();
    }

    /// <summary>행동 횟수를 초기화하고 현재 지원자의 이미지를 표시합니다.</summary>
    void StartInterview()
    {
        //
        questionCount = 0;
        applicantImage.sprite = GameDatabase.Instance.spritesApplicants[Index];
        /*string spriteURL = GameDatabase.Instance.Applicants.applicants[Index].image_url;
        if (spriteURL != null)
            applicantImage.sprite = Resources.Load<Sprite>("Sprites/Applicants/" + spriteURL);*/
    }
    /// <summary>다가가기 행동을 한 번 실행하고 지원자의 반응을 대화창에 추가합니다.</summary>
    void Approach()
    {
        //
        if (hasApproached)
            return;     // 占싱뱄옙 占쌕곤옙占쏙옙 占쏙옙占?占쏙옙占쏙옙

        hasApproached = true;

        if (questionCount >= maxQuestionCount)
            return;     // 占쌍댐옙 占쏙옙占쏙옙 占쏙옙占쏙옙 占십곤옙占쏙옙 占쏙옙占?占쏙옙占쏙옙

        questionCount++;
        AddLog(catName, "?ㅺ?媛꾨떎");
        AddLog(GameDatabase.Instance.Applicants.applicants[Index].name, GameDatabase.Instance.Applicants.applicants[Index].reaction_approach);

       /* ExActPanel.transform.Find("Ex1Button").GetComponent<Button>().onClick.AddListener(() => AddLog(GameDatabase.Instance.Applicants.applicants[Index].reaction_approach_ex1));
        ExActPanel.transform.Find("Ex2Button").GetComponent<Button>().onClick.AddListener(() => AddLog(GameDatabase.Instance.Applicants.applicants[Index].reaction_approach_ex2));
        ExActPanel.SetActive(true);*/
        
    }

    /// <summary>노려보기 행동을 한 번 실행하고 지원자의 반응을 대화창에 추가합니다.</summary>
    void Stare()
    {
        //
        if (hasStared)
            return;     // 占싱뱄옙 占쏙옙占쏙옙占?占쏙옙占?占쏙옙占쏙옙

        hasStared = true;

        if (questionCount >= maxQuestionCount)
            return;     // 占쌍댐옙 占쏙옙占쏙옙 占쏙옙占쏙옙 占십곤옙占쏙옙 占쏙옙占?占쏙옙占쏙옙

        questionCount++;
        AddLog(catName,"?몃젮蹂몃떎");
        AddLog(GameDatabase.Instance.Applicants.applicants[Index].name, GameDatabase.Instance.Applicants.applicants[Index].reaction_stare);
    }

    /// <summary>냄새 맡기 행동을 한 번 실행하고 지원자의 반응을 대화창에 추가합니다.</summary>
    void Smell()
    {
        //
        if (hasSmelled)
            return;     // 占싱뱄옙 占쏙옙占쏙옙 占쏙옙占쏙옙 占쏙옙占?占쏙옙占쏙옙

        hasSmelled = true;

        if (questionCount >= maxQuestionCount)
            return;     // 占쌍댐옙 占쏙옙占쏙옙 占쏙옙占쏙옙 占십곤옙占쏙옙 占쏙옙占?占쏙옙占쏙옙

        questionCount++;
        AddLog(catName, "?꾩깉 留〓뒗??);
        AddLog(GameDatabase.Instance.Applicants.applicants[Index].name, GameDatabase.Instance.Applicants.applicants[Index].reaction_smell);
    }

    /// <summary>위협하기 행동을 한 번 실행하고 지원자의 반응을 대화창에 추가합니다.</summary>
    void Threat()
    {
        //
        if (hasThreatened)
            return;     // 占싱뱄옙 占쏙옙占쏙옙占쏙옙 占쏙옙占?占쏙옙占쏙옙

        hasThreatened = true;

        if (questionCount >= maxQuestionCount)
            return;     // 占쌍댐옙 占쏙옙占쏙옙 占쏙옙占쏙옙 占십곤옙占쏙옙 占쏙옙占?占쏙옙占쏙옙

        questionCount++;
        AddLog(catName, "?꾪삊?쒕떎");
        AddLog(GameDatabase.Instance.Applicants.applicants[Index].name, GameDatabase.Instance.Applicants.applicants[Index].reaction_threat);
    }

    /// <summary>지원자의 채용 여부를 선택할 간택 패널을 엽니다.</summary>
    void Decide()
    {
        GanteakPanel.SetActive(true);
        
    }

    /// <summary>채용 여부에 따라 지원자 보유 ID를 변경하고 결과 패널을 표시합니다.</summary>
    /// <param name="isPassed">지원자를 채용하면 true, 거절하면 false입니다.</param>
    void ShowResult(bool isPassed)
    {
        if (isPassed)
        {
            ResultText.text = "媛꾪깮?덉뒿?덈떎!";
            GameState.Instance.ownedApplicantIds.Add(GameDatabase.Instance.Applicants.applicants[Index].id);
        }
        else
        {
            ResultText.text = "媛꾪깮?섏? ?딆븯?듬땲??";
            GameState.Instance.ownedApplicantIds.Remove(GameDatabase.Instance.Applicants.applicants[Index].id);    // 占쏙옙占쌌곤옙 占쏙옙占쏙옙 (1占쏙옙 占쌌곤옙, 0占쏙옙 占쏙옙占쌌곤옙)
        }

        GanteakPanel.SetActive(false);
        ResultPanel.SetActive(true);
        GameState.Instance.RefreshOwnedList();
    }

    /*void Next()
    {
        if (Index >= gameState.applicantDataList.Count)
            return;

        GlobalValue.interviewIndex++;
        ResultPanel.SetActive(false);
        SceneManager.LoadScene("ResumeScene");
        
    }*/

    /// <summary>마을 씬으로 이동합니다.</summary>
    void Town()
    {
        SceneManager.LoadScene("TownScene");
    }

    /// <summary>화자 이름이 없는 대화 로그 한 줄을 생성합니다.</summary>
    void AddLog(string log)
    {
        GameObject logText = Instantiate(textPrefab, DialogBox.transform); // 새로 생성한 대화 Text 오브젝트입니다.
        logText.GetComponent<Text>().text = log;
    }

    /// <summary>화자 이름과 내용을 조합한 대화 로그 한 줄을 생성합니다.</summary>
    void AddLog(string name, string log)
    {
        GameObject logText = Instantiate(textPrefab, DialogBox.transform); // 새로 생성한 대화 Text 오브젝트입니다.
        logText.GetComponent<Text>().text = name + ":" + log;
    }

    /// <summary>사용한 행동 수를 기준으로 남은 행동 횟수를 표시합니다.</summary>
    void ShowCount()
    {
        CountText.text = "?⑥? ?됰룞\n" + (maxQuestionCount - questionCount) + "/" + maxQuestionCount;
    }

    /// <summary>면접 메모 패널을 표시합니다.</summary>
    public void ShowMemo()
    {
        // 占쌨몌옙 占쏙옙占쏙옙占쌍댐옙 占쌉쇽옙
        memoPanel.SetActive(true);
    }

    /// <summary>면접 메모 패널을 숨깁니다.</summary>
    public void HideMemo()
    {
        // 占쌨몌옙 占쏙옙占쏙옙占?占쌉쇽옙
        memoPanel.SetActive(false);
    }

    /// <summary>지원자 이력서 패널을 표시합니다.</summary>
    public void ShowDocument()
    {
        resumePanel.SetActive(true);
    }

    /// <summary>지원자 이력서 패널을 숨깁니다.</summary>
    public void HideDocument()
    {
        resumePanel.SetActive(false);
    }
}

