using System.Linq;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InterviewMgr : MonoBehaviour
{
    int Index = 0;
    int questionCount = 0;
    int maxQuestionCount = 3;

    [Header("Interview")]
    // �⺻ �ൿ ��ư��
    public Button ApproachBtn;
    public Button StareBtn;
    public Button SmellBtn;
    public Button IgnoreBtn;
    public Button DecideBtn;
    public Button AcceptBtn;
    public Button RejectBtn;

    public GameObject ExActPanel; // �߰� �ൿ �г�

    public Text CountText;

    [Header("Result")]
    public Text ResultText;
    public Button NextBtn;
    public Button TownBtn;

    public Image applicantImage;

    public GameObject GanteakPanel;
    public GameObject ResultPanel;
    public GameObject DialogBox;

    public GameObject textPrefab;

    public GameObject memoPanel;
    public GameObject documentPanel;

    string catName = "�����";

    bool hasApproached = false;
    bool hasStared = false;
    bool hasSmelled = false;
    bool hasIgnored = false;

    GameState gameState;
    GameDatabase gameDatabase;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Index = 0; // ���� ���� ���� �ִ� �������� �ε���
        gameState = FindAnyObjectByType<GameState>();
        gameDatabase = FindAnyObjectByType<GameDatabase>();
        ApproachBtn.onClick.AddListener(Approach);
        StareBtn.onClick.AddListener(Stare);
        SmellBtn.onClick.AddListener(Smell);
        IgnoreBtn.onClick.AddListener(Ignore);

        GanteakPanel.SetActive(false);
        DecideBtn.onClick.AddListener(Decide);
        AcceptBtn.onClick.AddListener(() => ShowResult(true));
        RejectBtn.onClick.AddListener(() => ShowResult(false));
        //NextBtn.onClick.AddListener(Next);
        TownBtn.onClick.AddListener(Town);

        //StartInterview();
    }

    // Update is called once per frame
    void Update()
    {
        ShowCount();
    }

    void StartInterview()
    {
        //
        questionCount = 0;
        string spriteURL = gameDatabase.Applicants.ApplicantsDictionary[Index].image_url;
        if (spriteURL != null)
            applicantImage.sprite = Resources.Load<Sprite>("Images/" + spriteURL);
    }
    void Approach()
    {
        //
        if (hasApproached)
            return;     // �̹� �ٰ��� ��� ����

        hasApproached = true;

        if (questionCount >= maxQuestionCount)
            return;     // �ִ� ���� ���� �ʰ��� ��� ����

        questionCount++;
        AddLog(catName, "�ٰ�����");
        AddLog(gameDatabase.Applicants.ApplicantsDictionary[Index].name, gameDatabase.Applicants.ApplicantsDictionary[Index].reaction_approach);

        ExActPanel.transform.Find("Ex1Button").GetComponent<Button>().onClick.AddListener(() => AddLog(gameDatabase.Applicants.ApplicantsDictionary[Index].reaction_approach_ex1));
        ExActPanel.transform.Find("Ex2Button").GetComponent<Button>().onClick.AddListener(() => AddLog(gameDatabase.Applicants.ApplicantsDictionary[Index].reaction_approach_ex2));
        ExActPanel.SetActive(true);
        
    }

    void Stare()
    {
        //
        if (hasStared)
            return;     // �̹� ����� ��� ����

        hasStared = true;

        if (questionCount >= maxQuestionCount)
            return;     // �ִ� ���� ���� �ʰ��� ��� ����

        questionCount++;
        AddLog(catName,"�������");
        AddLog(gameDatabase.Applicants.ApplicantsDictionary[Index].name, gameDatabase.Applicants.ApplicantsDictionary[Index].reaction_stare);
    }

    void Smell()
    {
        //
        if (hasSmelled)
            return;     // �̹� ���� ���� ��� ����

        hasSmelled = true;

        if (questionCount >= maxQuestionCount)
            return;     // �ִ� ���� ���� �ʰ��� ��� ����

        questionCount++;
        AddLog(catName, "���� �ô´�");
        AddLog(gameDatabase.Applicants.ApplicantsDictionary[Index].name, gameDatabase.Applicants.ApplicantsDictionary[Index].reaction_smell);
    }

    void Ignore()
    {
        //
        if (hasIgnored)
            return;     // �̹� ������ ��� ����

        hasIgnored = true;

        if (questionCount >= maxQuestionCount)
            return;     // �ִ� ���� ���� �ʰ��� ��� ����

        questionCount++;
        AddLog(catName, "�����Ѵ�");
        AddLog(gameDatabase.Applicants.ApplicantsDictionary[Index].name, gameDatabase.Applicants.ApplicantsDictionary[Index].reaction_ignore);
    }

    void Decide()
    {
        GanteakPanel.SetActive(true);
        
    }

    void ShowResult(bool isPassed)
    {
        if (isPassed)
        {
            ResultText.text = "�հ��Դϴ�!";
            gameState.ownedApplicantIds.Add(gameDatabase.Applicants.ApplicantsDictionary[Index].id);
        }
        else
        {
            ResultText.text = "���հ��Դϴ�!";
            gameState.ownedApplicantIds.Remove(gameDatabase.Applicants.ApplicantsDictionary[Index].id);    // ���հ� ���� (1�� �հ�, 0�� ���հ�)
        }

        GanteakPanel.SetActive(false);
        ResultPanel.SetActive(true);
    }

    /*void Next()
    {
        if (Index >= gameState.applicantDataList.Count)
            return;

        GlobalValue.interviewIndex++;
        ResultPanel.SetActive(false);
        SceneManager.LoadScene("ResumeScene");
        
    }*/

    void Town()
    {
        SceneManager.LoadScene("TownScene");
    }

    void AddLog(string log)
    {
        GameObject logText = Instantiate(textPrefab, DialogBox.transform);
        logText.GetComponent<Text>().text = log;
    }

    void AddLog(string name, string log)
    {
        GameObject logText = Instantiate(textPrefab, DialogBox.transform);
        logText.GetComponent<Text>().text = name + ":" + log;
    }

    void ShowCount()
    {
        CountText.text = "���� �ൿ\n" + (maxQuestionCount - questionCount) + "/" + maxQuestionCount;
    }

    public void ShowMemo()
    {
        // �޸� �����ִ� �Լ�
        memoPanel.SetActive(true);
    }

    public void HideMemo()
    {
        // �޸� ����� �Լ�
        memoPanel.SetActive(false);
    }

    public void ShowDocument()
    {
        documentPanel.SetActive(true);
    }

    public void HideDocument()
    {
        documentPanel.SetActive(false);
    }
}
